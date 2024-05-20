# MinimapAPIs

You can test this on Windows or Linux
You need bash installed to run this on Windows

## Requirements

.Net 8
Golang
Rust (with cargo)

## Results on my computer

| Scenario        | Total requests served | % Faster |
| --------------- | --------------------- | -------- |
| Controllers     | 317 617               | 0.00     |
| Minimal API     | 342 113               | 7.16     |
| Golang with Chi | 387 354               | 18.00    |
| Rust with Axum  | 798 569               | 60.23%   |
