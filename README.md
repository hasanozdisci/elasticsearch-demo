# Elasticsearch .NET Core Web API Project

## Overview

This project is a .NET Core Web API that integrates with Elasticsearch to manage and search articles. The API provides endpoints to create, read, update, delete, and search articles using Elasticsearch, allowing for efficient full-text search and real-time indexing.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete articles.
- **Full-Text Search**: Search articles by title and content using Elasticsearch with support for partial matches and case insensitivity.
- **Elasticsearch Integration**: Automatic indexing and searching with Elasticsearch.

## Technologies Used

- **.NET Core**: Web API framework.
- **Elasticsearch**: Search and analytics engine.
- **Entity Framework Core**: ORM for managing database operations.
- **Docker**: Containerization for Elasticsearch.
- **AutoMapper**: For mapping between models and DTOs.

## Getting Started

### Prerequisites

- **.NET SDK**: Version 6.0 or later.
- **Docker**: For running Elasticsearch.
- **SQL Server**: Local or cloud-based instance for the database.

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   cd your-repo-name

### Set up Elasticsearch using Docker:
To set up Elasticsearch using Docker, you can follow these steps:

1. Pull the Elasticsearch Docker image:

   ```bash
   docker pull docker.elastic.co/elasticsearch/elasticsearch:7.15.0
   ```

2. Create a Docker network:

   ```bash
   docker network create elastic-network
   ```

3. Start an Elasticsearch container:

   ```bash
   docker run -d --name elasticsearch --net elastic-network -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" docker.elastic.co/elasticsearch/elasticsearch:8.15.0
   ```

   This command starts an Elasticsearch container named "elasticsearch" and exposes ports 9200 and 9300 for communication.

4. Verify that Elasticsearch is running:

   ```bash
   curl http://localhost:9200
   ```

   You should see a JSON response indicating the Elasticsearch version and other details.

Now you have Elasticsearch running in a Docker container. You can proceed with configuring and using it in your .NET Core Web API.


