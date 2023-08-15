Invoke-WebRequest http://localhost:5000/api/products -Method POST `
    -Body (@{ Name="Boot Laces" } | ConvertTo-Json) -ContentType "application/json"

