# Git & GitHub Instructions for ApiDemo Project

This file explains how to set up Git, connect to GitHub using SSH, and push the ApiDemo project.

---
## 1. Setting up Git (first time only)
Check if Git is installed:
```bash
git --version
```
If not, download from https://git-scm.com/

---
## 2. Configure Git (first time only)
Set your username and email (this will appear in commits):
```bash
git config --global user.name "Your Name"
git config --global user.email "your-email@example.com"
```

Check your configuration:
```bash
git config --list
```

---
## 3. Setting up SSH with GitHub
1. Generate a new SSH key (if you don’t already have one):
```bash
ssh-keygen -t ed25519 -C "your-email@example.com"
```
Press **Enter** to accept defaults. Add a passphrase if you like.

2. Start the SSH agent:
```bash
eval "$(ssh-agent -s)"
ssh-add ~/.ssh/id_ed25519
```

3. Copy the SSH key to your clipboard:
```bash
cat ~/.ssh/id_ed25519.pub
```
Copy the output and add it to GitHub:  
Go to **GitHub → Settings → SSH and GPG Keys → New SSH key**.

4. Test your connection:
```bash
ssh -T git@github.com
```
You should see: *"Hi username! You've successfully authenticated."*

---
## 4. Initialize the Repo Locally
Run these commands in the **ApiDemo** folder:
```bash
git init
git add .
git commit -m "Initial commit - C# API demo project"
```

---
## 5. Connect to GitHub
On GitHub, create a new repo named **ApiDemo** (do not add README).  
Then connect your local repo to GitHub:
```bash
git remote add origin git@github.com:YOUR-USERNAME/ApiDemo.git
```

---
## 6. Push to GitHub
```bash
git branch -M main
git push -u origin main
```

---
## 7. Common Git Commands
- Check repo status:
```bash
git status
```

- See commit history:
```bash
git log --oneline
```

- Create a new branch:
```bash
git checkout -b feature-branch
```

- Switch branches:
```bash
git checkout main
```

- Pull latest changes:
```bash
git pull origin main
```

- Push changes:
```bash
git push origin feature-branch
```

---
## 8. Notes for Students
- **Clone the repo** to your machine:
```bash
git clone git@github.com:YOUR-USERNAME/ApiDemo.git
```
- Always **pull** before starting new work:
```bash
git pull
```
- Commit messages should explain *why* the change was made, not just *what*.

---
Happy coding 🚀
