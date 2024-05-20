package main

import (
	"encoding/json"
	"net/http"

	"github.com/go-chi/chi/v5"
)

// User represents a user object
type User struct {
	ID        int    `json:"id"`
	Email     string `json:"email"`
	Username  string `json:"username"`
	FirstName string `json:"firstName"`
	LastName  string `json:"lastName"`
}

// userHandler handles the user endpoint
func userHandler(w http.ResponseWriter, _ *http.Request) {
	user := User{
		ID:        10000000,
		Email:     "tberg@stormgeo.com",
		Username:  "tberg",
		FirstName: "Terje",
		LastName:  "Bergeesen",
	}
	// Set the content type to application/json
	w.Header().Set("Content-Type", "application/json")

	// Encode the user to JSON and write it to the response
	json.NewEncoder(w).Encode(user)
}

func main() {
	r := chi.NewRouter()
	r.Get("/api/users/1", userHandler)
	println("Starting server on port 5003")
	err := http.ListenAndServe(":5003", r)
	if err != nil {
		panic(err)
	}
}
