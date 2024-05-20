# MinimapAPIs

You can test this on Windows or Linux
You need bash installed to run this on Windows

## Requirements

.Net 8
Golang
Rust (with cargo)

## Results on my computers

<table>
    <tr>
        <th>Scenario</th>
        <th>Total requests served</th>
        <th>% Faster</th>
    </tr>
    <tr>
        <td>Controllers</td>
        <td style="text-align: right">317 617</td>
        <td style="text-align: right">0.00</td>
    </tr>
    <tr>
        <td>Minimal API</td>
        <td style="text-align: right">342 113</td>
        <td style="text-align: right">7.16</td>
    </tr>
    <tr>
        <td>Golang with Chi</td>
        <td style="text-align: right">387 354</td>
        <td style="text-align: right">18.00</td>
    </tr>
    <tr>
        <td>Rust with Axum</td>
        <td style="text-align: right">798 569</td>
        <td style="text-align: right">60.23</td>
    </tr>
</table>
