# Graphql Example With Hotchocolate

A beginner-friendly GraphQL API project built with **.NET 7** and **HotChocolate** to demonstrate real-world usage of GraphQL in a .NET environment. This project provides CRUD operations, real-time subscriptions, and GraphQL Voyager for visualization. Perfect for those who want to learn GraphQL and best practices in .NET!

---

## 🚀 Features

- **GraphQL with HotChocolate**: Includes Queries, Mutations, and Subscriptions.
- **SQLite Database**: Lightweight and easy-to-setup database for demo purposes.
- **GraphQL Voyager**: Visualize your GraphQL schema with an interactive UI.
- **Filtering & Sorting**: Built-in support for GraphQL filtering and sorting.
- **In-Memory Subscriptions**: Real-time data updates using WebSockets.
- **CORS Support**: Configured to handle cross-origin requests.
- **Swagger Integration**: Explore REST endpoints alongside your GraphQL API.
- **Modular Code Design**: Follows clean architecture principles and .NET best practices.

---

## 🛠️ Tech Stack

- **.NET 7**
- **HotChocolate (GraphQL for .NET)**
- **Entity Framework Core** with **SQLite**
- **GraphQL Voyager** for schema visualization
- **Swagger/OpenAPI** for REST API documentation
- **CORS Configuration** for flexible API accessibility
- **In-Memory Subscriptions** for real-time GraphQL operations

---

## 📂 Project Structure

```bash
ToDoQL
├── Data                # Contains the DbContext and Entity models
├── GraphQL             # Contains GraphQL schema, resolvers, and types
│   ├── Query.cs        # Defines GraphQL queries
│   ├── Mutation.cs     # Defines GraphQL mutations
│   ├── Subscription.cs # Defines GraphQL subscriptions
│   ├── ItemType.cs     # Type definitions for Item
│   └── ItemListsType.cs# Type definitions for Item Lists
├── Program.cs          # Application entry point
├── appsettings.json    # Configuration file for database connections
└── Startup.cs          # Configures services and middleware
```

## ⚙️ Installation

### Prerequisites

- [.NET SDK 7.0+](https://dotnet.microsoft.com/download)
- [SQLite](https://www.sqlite.org/index.html) (pre-installed in .NET; no setup required)
- A REST client like [Postman](https://www.postman.com/) or a GraphQL client like [Altair](https://altair.sirmuel.design/)

### Steps to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/dipjyotisikder/graphql-example-with-hotchocolate.git
   cd graphql-example-with-hotchocolate
   ```
2. **Restore dependencies**:
   Run the following command to restore the required packages:
   ```bash
   dotnet restore
   ```
2. **Apply database migrations**  
   Ensure the SQLite database is set up by applying migrations:
   ```
   dotnet ef database update
   ```

3. **Run the application**  
   Start the application by running:
   ```
   dotnet run
   ```

4. **Access the application**  
   Open the following URLs in your browser:
   - **GraphQL Playground**: [https://localhost:5001/graphql](https://localhost:5001/graphql)  
     Explore the GraphQL API and test queries, mutations, and subscriptions.
   - **GraphQL Voyager**: [https://localhost:5001/graphql-ui](https://localhost:5001/graphql-ui)  
     Visualize your GraphQL schema and relationships.
   - **Swagger UI**: [https://localhost:5001/swagger](https://localhost:5001/swagger)  
     Access REST API documentation (if applicable).

---

## 🛠️ Usage

### GraphQL Playground  
Use the Playground at `/graphql` to run GraphQL queries, mutations, and subscriptions interactively.

### GraphQL Voyager  
Visualize the API schema at `/graphql-ui` to understand the relationships between types.
---

## 🚀 Example Queries

### Queries
Fetch all item lists along with their items:
```
query {
  itemLists {
    id
    name
    items {
      id
      title
      isComplete
    }
  }
}
```

Fetch items filtered by their completion status:
```
query {
  items(where: { isComplete: true }) {
    id
    title
  }
}
```

### Mutations
Add a new item to an existing list:
```
mutation {
  addItem(input: { title: "New Task", itemListId: 1 }) {
    id
    title
    isComplete
  }
}
```

Update an existing item:
```
mutation {
  updateItem(id: 1, input: { title: "Updated Task", isComplete: true }) {
    id
    title
    isComplete
  }
}
```

### Subscriptions
Listen for changes to items in real time:
```
subscription {
  onItemChanged {
    id
    title
    isComplete
  }
}
```

---

## 🔗 Useful Links

- [HotChocolate Documentation](https://chillicream.com/docs/hotchocolate)
- [GraphQL Voyager](https://github.com/APIs-guru/graphql-voyager)
- [SQLite Documentation](https://www.sqlite.org/docs.html)

---

## 🙌 Contributing

Contributions are welcome! Feel free to fork this repository, make improvements, and submit a pull request.

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

---

## ❤️ Acknowledgments

Thanks to the **HotChocolate** and **.NET** communities for providing excellent tools and resources to make GraphQL development accessible for everyone.
