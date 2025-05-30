# Order Management System

A .NET 8 Web API project implementing an order management system with advanced features including discount system, order status tracking, and analytics.

## Features

- Discount System:
  - Multiple discount rules based on customer segments
  - Order history-based discounts
  - Flexible discount calculation strategy

- Order Status Tracking:
  - Valid state transitions (Created → Processing → Shipped/Delivered/Cancelled)
  - Timestamp tracking for status changes
  - Validation for invalid state transitions

- Order Analytics:
  - Average order value calculation
  - Average fulfillment time metrics
  - Order count by status
  - Average value by customer segment

## Technical Stack

- .NET 8
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI for API documentation
- NUnit for testing

## Project Structure

```
OrderManagementSystem
├── OrderManagementSystem.Models
├── OrderManagementSystem.Services
├── OrderManagementSystem.Tests
└── OrderManagementSystem
```

## Setup Instructions

1. Clone the repository:
```bash
git clone https://github.com/YOUR_USERNAME/OrderManagementSystem.git
```

2. Install dependencies:
```bash
dotnet restore
```

3. Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }
}
```

4. Run database migrations:
```bash
dotnet ef database update
```

5. Run the application:
```bash
dotnet run
```

## API Documentation

Swagger UI is available at `/swagger` when running the application.

## Testing

Run tests using:
```bash
dotnet test
```

## Assumptions

1. The system uses a SQL Server database
2. Customer segments are defined as Regular, Silver, Gold, and Platinum
3. Discount rates are configurable through discount rules
4. Order status transitions follow a strict state machine pattern

## Performance Considerations

1. Efficient query design in analytics endpoints
2. Proper database indexing
3. Caching mechanisms for frequently accessed data
4. Lazy loading implemented where appropriate

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

[MIT License](LICENSE)

## Contact

For support or questions, please open an issue in the repository.
