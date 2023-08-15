Invoke-RestMethod http://localhost:5000/api/products -Method POST `
    -Body (@{ Name="Soccer Boots"; Price=89.99; CategoryId=2; SupplierId=2} | `
    ConvertTo-Json) -ContentType "application/json"