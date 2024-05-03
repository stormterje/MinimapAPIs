package handlers

import (
	"fmt"
	"net/http"
)

type Users struct{}

func (o *Users) Create(w http.ResponseWriter, r *http.Request) {
	fmt.Println("Create an user")
}

func (o *Users) List(w http.ResponseWriter, r *http.Request) {
	fmt.Println("List all users")
}

func (o *Users) GetByID(w http.ResponseWriter, r *http.Request) {
	fmt.Println("Get an user by ID")
}

func (o *Users) UpdateByID(w http.ResponseWriter, r *http.Request) {
	fmt.Println("Update an user by ID")
}

func (o *Users) DeleteByID(w http.ResponseWriter, r *http.Request) {
	fmt.Println("Delete an user by ID")
}
