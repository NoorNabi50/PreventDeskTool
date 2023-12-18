 <h1>Project Title: PreventDeskTool - Final Year Project Web Module</h1>


  <h2 id="description">Description</h2>
    <p>PreventDeskTool is the web module of my final year project.</p>
    The aim of this project was
    <ul>
     <li>To Educate children about road safety.</li>
     <li>To introduce activity for students in schools that will educate them about traffic rules and regulations in a healthy and fun way.</li>
     <li>Providing fun and leisure activity for children by making them play this game.</li>
     <li>To Reduce the number of hazardous accidents by giving education to students at a very young age.  </li>
</li>
    </ul>
   <hr>

   <h2 id="technologies-used">Technologies Used</h2>
    <p>The following technologies were used in this project:</p>
    <ol>
        <li>ASP.NET Core MVC: This framework was used to build the web application.</li>
        <li>MSSQL Server Database: The database management system for storing project data.</li>
        <li>Entity Framework Core ORM: Used for data modeling and interaction with the database.</li>
        <li>Chart.js Library: Utilized to create interactive data visualizations and charts.</li>
        <li>SweetAlert.js Library: For enhancing user alerts and notifications.</li>
        <li>JavaScript/jQuery: Used for client-side scripting and enhancing user experience.</li>
        <li>Bootstrap: For responsive and visually appealing user interface components.</li>
    </ol>
    <h2>Installation Guide</h2>
    <p>To get started with the PreventDeskTool, follow these steps:</p>
    <ol>
        <li><strong>Prerequisites</strong>: Ensure you have the latest .NET Core SDK installed on your system. You can download it from <a href="https://dotnet.microsoft.com/download">here</a>.</li>
        <li><strong>Clone the Repository</strong>: Clone the project to your local machine using Git:
            <pre>git clone https://github.com/NoorNabi50/PreventDeskTool.git</pre>
        </li>
        <li><strong>Restore Dependencies</strong>: Navigate to the project directory and execute the following command to restore all the necessary dependencies:
            <pre>dotnet restore</pre>
        </li>
        <li><strong>Set Up the Database</strong>: Ensure that MSSQL Server is installed and properly configured. Update the connection string in the <code>appsettings.json</code> file to match your database settings.</li>
        <li><strong>Run Entity Framework Migrations</strong>: To set up your database schema, use Entity Framework migrations:
            <pre>dotnet ef database update</pre>
        </li>
        <li><strong>Run the Application</strong>: Start the application by running:
            <pre>dotnet run</pre>
            This will start the ASP.NET Core application on the default port. You can access the web application by navigating to <code>http://localhost:5000</code> in your web browser.</li>
    </ol>
