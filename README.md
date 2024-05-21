# MinimapAPIs

You can test this on Windows or Linux
You need bash installed to run this on Windows

## Requirements

.Net 8
Golang
Rust (with cargo)

## Results on my computer

| Scenario        | Total requests served | % Faster |
| :-------------- | --------------------: | -------: |
| Controllers     |               317 617 | Baseline |
| Minimal API     |               342 113 |      7.7 |
| Golang with Chi |               387 354 |     22.0 |
| Rust with Axum  |               798 569 |    151.4 |
