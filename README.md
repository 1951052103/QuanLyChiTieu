# QuanLyChiTieu

Install-Package Microsoft.EntityFrameworkCore -version 5.0.10
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 5.0.10
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 5.0.10

Scaffold-DbContext "Data Source=.;Initial Catalog=QuanLyChiTieu;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
