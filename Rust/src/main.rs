use axum::{
    routing::get,
    Router,
    Json,
};
use serde::{Deserialize, Serialize};

#[derive(Serialize, Deserialize)]
struct User {
    id: u32,
    email: String,
    username: String,
    first_name: String,
    last_name: String,
}

async fn user_handler() -> Json<User> {
    let user = User {
        id: 10000000,
        email: "tberg@stormgeo.com".to_string(),
        username: "tberg".to_string(),
        first_name: "Terje".to_string(),
        last_name: "Bergesen".to_string(),
    };
    Json(user)
}

#[tokio::main]
async fn main() {
    // build our application with a single route
    let app = Router::new().route("/api/users/1", get(user_handler));

    // run our app with hyper, listening globally on port 5004
    let listener = tokio::net::TcpListener::bind("0.0.0.0:5004").await.unwrap();
    axum::serve(listener, app).await.unwrap();
}