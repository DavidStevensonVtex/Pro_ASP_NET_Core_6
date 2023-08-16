$r = Invoke-WebRequest http://localhost:5000/api/content/string 
# $r
"Status Code: $($r.StatusCode)   Content-Type: $($r.Headers["Content-Type"])"
"Content: $($r.Content)"

# Status Code: 200   Content-Type: text/plain; charset=utf-8
# Content: This is a string response