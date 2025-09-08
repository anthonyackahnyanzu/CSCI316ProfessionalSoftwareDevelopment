# ApiDemo - C# HTTP Verbs & Error Handling Demo

This project demonstrates how to use **C# and HttpClient** to call REST APIs.  
It shows the main HTTP verbs (GET, POST, PUT, PATCH, DELETE) and how to handle common errors.  
It is designed as a **teaching tool** for students learning APIs and GitHub.

---

## 🚀 Features Demonstrated
- **GET**: Fetch a resource from an API.
- **POST**: Create a new resource.
- **PUT**: Fully update an existing resource.
- **PATCH**: Partially update an existing resource.
- **DELETE**: Remove a resource.
- **Error Handling**:
  - 400 Bad Request
  - 401 Unauthorized
  - 403 Forbidden
  - 404 Not Found
  - 500 Internal Server Error
  - Timeout handling

The API used is [JSONPlaceholder](https://jsonplaceholder.typicode.com), a free fake API for testing.

---

## 📦 Running the Project
1. Ensure you have [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) installed.
2. Clone or download this project.
3. From the project root, run:
   ```bash
   dotnet run
   ```
4. You’ll see console output demonstrating each HTTP verb and error type.

---

## 🌐 Example Output
```
--- GET ---
Fetched Post 1: sunt aut facere repellat provident occaecati excepturi optio reprehenderit

--- POST ---
POST status: Created
{ "id": 101, "title": "Hello World", "body": "This is a new post.", "userId": 1 }

--- PUT ---
PUT status: OK
{ "id": 1, "title": "Updated Title", "body": "Updated Body", "userId": 1 }

--- PATCH ---
PATCH status: OK
{ "id": 1, "title": "Patched Title", ... }

--- DELETE ---
DELETE status: OK
```

---

## 🐙 GitHub Instructions for Students

### 1. Create a new repository on GitHub
- Go to [GitHub](https://github.com/).
- Click **New Repository**.
- Name it (example: `ApiDemo`).
- Do **not** initialize with README (we already have one).

### 2. Initialize Git in your local project
Open a terminal in your project folder:
```bash
git init
git add .
git commit -m "Initial commit - ApiDemo project"
```

### 3. Connect to your GitHub repository
Replace `YOUR-USERNAME` with your GitHub username:
```bash
git remote add origin git@github.com:YOUR-USERNAME/ApiDemo.git
```

### 4. Push the project to GitHub
```bash
git branch -M main
git push -u origin main
```

### 5. Common Workflow
- **Check repo status**:
  ```bash
  git status
  ```

- **Commit changes**:
  ```bash
  git add .
  git commit -m "Meaningful commit message"
  git push origin main
  ```

- **Clone an existing repo** (for classmates):
  ```bash
  git clone git@github.com:YOUR-USERNAME/ApiDemo.git
  ```

---

## 📚 Notes for Teachers
- Students can use this project to explore **HTTP verbs** and **API error handling**.
- GitHub workflow is included so they practice **version control**.
- This project can be extended to call other public APIs (e.g., weather, jokes, or Pokémon).

---

Happy coding & learning 🎉
