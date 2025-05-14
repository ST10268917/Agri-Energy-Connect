# 🌿 Agri-Energy Connect

## 🟢 Introduction
Agri-Energy Connect is a prototype web application built using ASP.NET Core MVC that facilitates collaboration between farmers and agricultural employees. The platform streamlines product management and provides role-based access to ensure a smooth, secure, and user-friendly experience.

---

## 🟢 Functional Requirements
- Relational database integration for storing user, category, and product data
- Two distinct user roles: **Farmer** and **Employee**
- Farmers can add and manage their products
- Employees can manage farmers and filter/search products
- Responsive and visually appealing UI using Bootstrap
- Role-based access control with secure authentication

---

## 🟢 Setup Instructions
1. Clone the repository
2. Open the solution in Visual Studio
3. Ensure you have .NET 8 SDK installed
4. Configure your database connection string in `appsettings.json`

---

## 🟢 Installation and Setup
```bash
# Restore NuGet packages
dotnet restore

# Apply EF Core migrations
Update-Database

# Run the application
dotnet run
```

---

## 🟢 Building and Running the Prototype

1. Open the solution in Visual Studio
2. Build the project using **Build > Build Solution**
3. Apply EF Core migrations (if not already done):
   ```bash
   Update-Database
   ```
4. Run the application using:
   - IIS Express (default)
   - Or `dotnet run` via terminal
5. Navigate to:  
   ```
   https://localhost:<your-port>
   ```
   to launch the app in your browser

---

## 🟢 System Functionalities and User Roles

### 👨‍🌾 Farmer
- Add products (name, description, price, quantity, category, image, production date)
- View all own products in a card-based layout
- Upload and store product images securely

### 💼 Employee
- Add new farmers with credentials
- View all farmers
- View and filter products by name, category, date, and farmer

---

## 🟢 Roadmap

### ✅ Completed
- User authentication and role-based access
- Product and farmer CRUD operations
- Filtering and searching products
- UI design with Bootstrap
- Factory and Strategy design pattern implementation

### ⏳ In Progress
- Observer pattern for event-based actions
- Admin log viewer using Singleton logger

### Planned
- Email notifications (Observer Design Pattern)
- Educational and Training resources
- Interactive forums and discussion boards for farmers
- Project collaboration and funding oppurtunities
- Mobile responsive and UI improvements

---

## 🟢 Images (Page Descriptions)

**Home Page**: Welcoming banner with a hero image, carousel, and "Join Now" button.  
![image](https://github.com/user-attachments/assets/a5db47a6-c70d-4000-a71d-3be0775e7efd)
![image](https://github.com/user-attachments/assets/c315d48f-68ca-40ba-932b-fcac3ca494b0)



**Login Page**: Clean and centered login/register interface with secure validation.  
![image](https://github.com/user-attachments/assets/27f14828-55e9-4827-9fa8-1c20562c7c8b)


**My Products Page**: Card layout showing farmer-specific products with image, price, quantity, date etc.  
![image](https://github.com/user-attachments/assets/f46414ba-27d5-404d-8dd5-cbb7f06023b8)
![image](https://github.com/user-attachments/assets/18e2211c-7d95-4c31-8e34-0d23c9722689)


**Products List Page**: Employee view with all products and advanced filters by name, category, date, and farmer. 
![image](https://github.com/user-attachments/assets/ee14c396-f3e7-4515-ab24-69ed2bc262ab)

**Farmers Page**: Employee interface showing a list of all registered farmers.
![image](https://github.com/user-attachments/assets/b0260c41-80ad-402a-af62-c909c97a337c)
![image](https://github.com/user-attachments/assets/591c3bb0-0961-4848-a96a-c5dabbf96baa)




---

## 🟢 Demo Video
[Add YouTube Link Here]

---

## 🟢 Technology Stack

**Tools and Languages Used:**

<p align="left">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" title="C#" width="48"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/visualstudio/visualstudio-plain.svg" title="Visual Studio" width="48"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-original.svg" title=".NET 8" width="48"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/bootstrap/bootstrap-original.svg" title="Bootstrap" width="48"/>
</p>


---

## 🟢 Coding Activity
- Code tracked using Git
- Design pattern usage: Singleton, Factory
- Adheres to N-Tier architecture (Presentation, Business, Data)

---

## 🟢 Get Started
- Use the Add Farmer feature to register farmers  
- Use My Products to create and track inventory  
- Employees can browse and filter available goods efficiently

---

## 🟢 Contributing
Contributions are welcome. Submit pull requests or feature requests through GitHub.

---

## Reference List
- American Farm Bureau. (n.d.). *Public Attitudes About Farmers and Farming*. Available at: [https://www.fb.org/focus-on-agriculture/public-attitudes-about-farmers-and-farming-a-golden-opportunity](https://www.fb.org/focus-on-agriculture/public-attitudes-about-farmers-and-farming-a-golden-opportunity) [Accessed 13 Jul. 2025].

- Bootstrap. (n.d.). *Carousel documentation*. Available at: [https://getbootstrap.com/docs/4.0/components/carousel/](https://getbootstrap.com/docs/4.0/components/carousel/) [Accessed 13 Jul. 2025].

- iStock. (n.d.). *Farm Photos*. Available at: [https://www.istockphoto.com/photos/farm](https://www.istockphoto.com/photos/farm) [Accessed 13 Jul. 2025].

- Lancaster Farming. (n.d.). *God Makes Himself Known on the Farm*. Available at: [https://www.lancasterfarming.com/country-life/family/god-makes-himself-known-on-the-farm/article_4b6a9ee3-1ee0-5852-9ba1-d812f6132026.html](https://www.lancasterfarming.com/country-life/family/god-makes-himself-known-on-the-farm/article_4b6a9ee3-1ee0-5852-9ba1-d812f6132026.html) [Accessed 13 Jul. 2025].

- PNGTree. (n.d.). *Mixed fruit background*. Available at: [https://pngtree.com/freepng/mixed-fruit-background_14574259.html](https://pngtree.com/freepng/mixed-fruit-background_14574259.html) [Accessed 13 Jul. 2025].




