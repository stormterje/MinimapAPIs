# MinimapAPIs

You can test this on Windows or Linux
You need bash installed to run this on Windows

## Requirements

.Net 8
Golang
Rust (with cargo)

## Results on my computer

<table>
    <tr>
        <th>Scenario</th>
        <th>Total requests served</th>
        <th>% Faster</th>
    </tr>
    <tr>
        <td>Controllers</td>
        <td>317 617</td>
        <td>0.00</td>
    </tr>
    <tr>
        <td>Minimal API</td>
        <td>342 113</td>
        <td>7.16</td>
    </tr>
    <tr>
        <td>Golang with Chi</td>
        <td>387 354</td>
        <td>18.00</td>
    </tr>
    <tr>
        <td>Rust with Axum</td>
        <td>798 569</td>
        <td>60.23</td>
    </tr>
</table>
