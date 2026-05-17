# CloudVault

A mobile and web application for storing images, files, and more in AWS cloud. This application combines the best features of Google Photos and Google Drive into a single unified platform.

## Overview

CloudVault is a modern, serverless cloud storage solution built with Blazor that leverages AWS services for backend operations. No traditional backend services are required—everything runs through AWS infrastructure.

## Features

### Image Management
- Upload and organize photos
- Automatic image optimization and thumbnails
- Image search and filtering
- Shared albums and galleries
- Collaborative image organization

### File Management
- Upload and download any file type
- Organize files into folders
- File versioning and history
- File sharing with access controls
- Search across all files

### Core Capabilities
- Cross-platform: Web and Mobile (iOS/Android)
- Real-time synchronization
- Offline access support
- Advanced search and tagging
- Collaborative sharing
- Access control and permissions

## Tech Stack

- **Frontend**: Blazor (C#/.NET)
- **Mobile**: Blazor Hybrid (iOS/Android)
- **Backend**: AWS Services (Serverless)
  - Amazon S3 for storage
  - AWS Lambda for processing
  - Amazon DynamoDB for metadata
  - Amazon Cognito for authentication
  - Amazon CloudFront for CDN
  - AWS SQS for messaging
  - Amazon EventBridge for orchestration

## Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                  CloudVault Frontend                         │
│  (Blazor Web + Blazor Hybrid Mobile)                        │
└──────────────────────┬──────────────────────────────────────┘
                       │
        ┌──────────────┼──────────────┐
        │              │              │
    ┌───▼────┐    ┌───▼────┐    ┌───▼────┐
    │ AWS S3 │    │DynamoDB│    │Cognito │
    │(Storage)│   │(Metadata)│   │(Auth)  │
    └────────┘    └────────┘    └────────┘
        │              │              │
        └──────────────┼──────────────┘
                       │
        ┌──────────────┼──────────────┐
        │              │              │
    ┌───▼────┐    ┌───▼────┐    ┌───▼────┐
    │ Lambda │    │EventBr.│    │CloudFr.│
    │(Process)│   │(Orches.)│   │(CDN)   │
    └────────┘    └────────┘    └────────┘
```

## Getting Started

### Prerequisites
- .NET 8.0 or later
- AWS Account with appropriate permissions
- AWS CLI configured
- Visual Studio 2022+ or VS Code

### Installation

1. Clone the repository:
```bash
git clone https://github.com/ReddyRomantic/cloudvault.git
cd cloudvault
```

2. Install dependencies:
```bash
dotnet restore
```

3. Configure AWS credentials:
```bash
aws configure
```

4. Set up environment variables:
```bash
cp .env.example .env
# Update .env with your AWS configuration
```

5. Run the application:
```bash
dotnet run
```

## Project Structure

```
cloudvault/
├── CloudVault.Web/                 # Blazor Web Application
│   ├── Pages/
│   ├── Components/
│   ├── Services/
│   └── wwwroot/
├── CloudVault.Mobile/              # Blazor Hybrid Mobile App
│   ├── Pages/
│   ├── Components/
│   └── Platforms/
├── CloudVault.Shared/              # Shared Models & Services
│   ├── Models/
│   ├── Services/
│   └── AWS/
├── CloudVault.Infrastructure/      # AWS Infrastructure as Code
│   ├── Terraform/
│   ├── CloudFormation/
│   └── Scripts/
└── CloudVault.Tests/               # Unit & Integration Tests
```

## AWS Services Configuration

### S3 Configuration
- Bucket for original files
- Bucket for optimized images
- Lifecycle policies for archival
- Versioning enabled

### DynamoDB Configuration
- Tables for metadata storage
- Global secondary indexes for queries
- TTL for temporary data
- Point-in-time recovery enabled

### Lambda Functions
- Image optimization and thumbnail generation
- File processing and indexing
- Email notifications
- Scheduled cleanup tasks

### Cognito Configuration
- User pools for authentication
- MFA support
- Social login integration
- Custom attributes

## Development Workflow

1. Create a feature branch:
```bash
git checkout -b feature/your-feature
```

2. Commit your changes:
```bash
git commit -am 'Add your feature'
```

3. Push to the branch:
```bash
git push origin feature/your-feature
```

4. Create a Pull Request

## Contributing

We welcome contributions! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

For support, please:
- Check existing [Issues](https://github.com/ReddyRomantic/cloudvault/issues)
- Create a new Issue with detailed description
- Contact: [your-email@example.com]

## Roadmap

- [ ] Core Web Application
- [ ] Mobile Application (iOS/Android)
- [ ] Advanced image features (ML-based search)
- [ ] Offline sync capabilities
- [ ] Collaborative features
- [ ] Enterprise SSO support
- [ ] Mobile app optimization

## Security

CloudVault implements:
- End-to-end encryption for sensitive files
- AWS KMS for key management
- VPC endpoints for private connectivity
- IAM policies for fine-grained access control
- Regular security audits and penetration testing

---

**Built with ❤️ using Blazor and AWS**
