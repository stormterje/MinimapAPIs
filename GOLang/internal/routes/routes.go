package routes

import (
	"fmt"
	"net/http"
)

func NewRouter() http.Handler {
	mux := http.NewServeMux()

	mux.HandleFunc("/", indexHandler)
	mux.HandleFunc("/api/users", usersHandler)

	return mux
}

func indexHandler(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintln(w, "Welcome to the home page")
}

func usersHandler(w http.ResponseWriter, r *http.Request) {
	data := "Some data from somewhere"
	fmt.Fprintln(w, data)
}
