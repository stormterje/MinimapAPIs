package app

import (
	"net/http"

	"github.com/go-chi/chi/middleware"
	"github.com/go-chi/chi/v5"
	"github.com/stormterje/gominapi/internal/handlers"
)

func loadRoutes() *chi.Mux {
	router := chi.NewRouter()

	router.Use(middleware.Logger)

	router.Get("/", func(w http.ResponseWriter, r *http.Request) {
		w.WriteHeader(http.StatusOK)
	})

	router.Route("/api/orders", loadOrderRoutes)
	router.Route("/api/users", loadUserRouted)

	return router
}

func loadOrderRoutes(router chi.Router) {
	orderHandler := &handlers.Order{}

	router.Post("/", orderHandler.Create)
	router.Get("/", orderHandler.List)
	router.Get("/{id}", orderHandler.GetByID)
	router.Put("/{id}", orderHandler.UpdateByID)
	router.Delete("/{id}", orderHandler.DeleteByID)
}

func loadUserRouted(router chi.Router) {
	usersHandler := &handlers.Users{}

	router.Post("/", usersHandler.Create)
	router.Get("/", usersHandler.List)
	router.Get("/{id}", usersHandler.GetByID)
	router.Put("/{id}", usersHandler.UpdateByID)
	router.Delete("/{id}", usersHandler.DeleteByID)
}
