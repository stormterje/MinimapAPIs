package main

import (
	"context"
	"fmt"

	app "github.com/stormterje/gominapi/internal"
)

func main() {
	app := app.New()

	err := app.Start(context.TODO())
	if err != nil {
		fmt.Println("failed to start app:", err)
	}
}
