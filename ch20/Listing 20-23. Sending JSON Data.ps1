Invoke-RestMethod http://localhost:5000/api/content -Method POST `
    -Body (@{ Name="Swimming Goggles"; Price=12.75; CategoryId=1; SupplierId=1} | `
    ConvertTo-Json) -ContentType "application/json"

# JSON: Swimming Goggles