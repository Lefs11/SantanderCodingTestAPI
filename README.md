# SantanderCodingTestAPI

## Overview
ASP.NET Core Web API retrieves the top `n` best Hacker News stories sorted by score.

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/Lefs11/SantanderCodingTestAPI.git
   cd HackerNewsBestStoriesAPI
   ```
2. Run the app:
   ```bash
   dotnet run
   ```
3. Visit Swagger UI:
   ```
   https://localhost:{port}/swagger
   ```

## Usage
Endpoint:
```
GET /api/stories/best?n=10
```
Returns the best stories, sorted by score, limited to `n`.

## Assumptions
- Results are cached to reduce API calls to Hacker News.

## Enhancements (Given More Time)
- Implement distributed caching (e.g., Redis)
- Add rate limiting & retry policy
- Add unit tests for the service layer
- Add background job to refresh cache periodically