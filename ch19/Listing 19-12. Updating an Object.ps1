Invoke-RestMethod http://localhost:5000/api/products -Method PUT `
    -Body (@{ ProductId=1; Name="Green Kayak"; Price=275; CategoryId=1; SupplierId=1} | `
    ConvertTo-Json) -ContentType "application/json"