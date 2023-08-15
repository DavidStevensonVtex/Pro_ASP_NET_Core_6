Invoke-RestMethod http://localhost:5000/api/products -Method POST `
    -Body (@{ ProductId=100; Name="Swim Buoy"; Price=19.99; CategoryId=1; SupplierId=1 } | `
    ConvertTo-Json) -ContentType "application/json"