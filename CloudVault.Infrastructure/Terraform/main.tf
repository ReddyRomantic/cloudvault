provider "aws" {
  region = var.aws_region
}

variable "aws_region" {
  default = "us-east-1"
}

resource "aws_s3_bucket" "cloudvault_optimized" {
  bucket = "cloudvault-optimized"
  acl    = "private"

  versioning {
    enabled = true
  }

  lifecycle_rule {
    enabled = true

    noncurrent_version_expiration {
      days = 30
    }
  }
}

resource "aws_s3_bucket" "cloudvault_original" {
  bucket = "cloudvault-original"
  acl    = "private"

  versioning {
    enabled = true
  }
}

resource "aws_dynamodb_table" "cloudvault_metadata" {
  name         = "CloudVaultMetadata"
  billing_mode = "PAY_PER_REQUEST"
  hash_key     = "FileId"
  attribute {
    name = "FileId"
    type = "S"
  }
  ttl {
    attribute_name = "TimeToLive"
    enabled        = true
  }
}

resource "aws_iam_role" "cloudvault_lambda_exec" {
  name = "cloudvault_lambda_exec"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action = "sts:AssumeRole"
        Effect = "Allow"
        Principal = {
          Service = "lambda.amazonaws.com"
        }
      },
    ]
  })
}

resource "aws_lambda_function" "cloudvault_thumb_gen" {
  function_name = "cloudvault-thumb-gen"
  role          = aws_iam_role.cloudvault_lambda_exec.arn
  handler       = "index.handler"
  runtime       = "nodejs18.x"
  s3_bucket     = aws_s3_bucket.cloudvault_original.bucket
}