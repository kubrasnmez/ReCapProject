<h1>GENEL BİLGİLER</h1>
<p>Entities, DataAccess, Business, Core ve WebAPI katmanlarından oluşan araç kiralama projesidir. Bu proje, Katmanlı mimari yapısı ve SOLID prensiplerini dikkate alınarak yazılmıştır. 
JWT entegrasyonu; Transaction, Cache, Validation ve Performance aspect'lerinin implementasyonu gerçekleştirilmiştir. OOP olarak entity framework kullanılmaktadır.
Validation için FluentValidation desteği, IoC için ise Autofac desteği eklenmiştir.</p>

<h4>Business Layer : </h4>
Bilgileri gerekli koşullara göre işlemek veya denetlemek için oluşturulmuştur. İş kuraları yazılır.
<br>
<h4>Data Access Layer</h4>
Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulmuştur.
<br>
<h4>Core Layer</h4>
Bir framework katmanı olan Core Katmanı'nda DataAccess, Entities, Utilities olmak üzere 3 adet klasör bulunmaktadır.
DataAccess klasörü DataAccess Katmanı ile ilgili nesneleri, Entities klasörü Entities katmanı ile ilgili nesneleri tutmak için oluşturulmuştur. 
Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. 
Core Katmanı, diğer katmanları referans almaz.
<br>


<h3>Packageces</h3>
<table>
<tr>
<td>Autofac 6.1.0 </td>
</tr>
<tr>
<td>Autofac.Extensions.DependencyInjection 7.1.0 </td>
</tr>
<tr>
<td>Autofac.Extras.DynamicProxy 6.0.0 </td>
</tr>
<tr>
<td>FluentValidation 10.0.2 </td>
</tr>
<tr>
<td>Microsoft.AspNetCore.Http 2.2.2 </td>
</tr>
<tr>
<td>Microsoft.Extensions.DependencyInjection 5.0.1 </td>
</tr>
<tr>
<td>NETStandard.Library </td>
</tr>
<tr>
<td>Microsoft.IdentityModel.Tokens 6.8.0 </td>
</tr>
<tr>
<td>Newtonsoft.Json 13.0.1 </td>
</tr>
<tr>
<td>Microsoft.EntityFrameworkCore.SqlServer 3.1.11 </td>
</tr>
<tr>
<td> Microsoft.AspNetCore.Authentication.JwtBearer 3.1.11 </td>
</tr>
</table>

<br>
<h4>Tablolar</h4>
<table>
<tr >
<td colspan = "2">Brands </td>
</tr>
<tr><td>BrandId</td>
<td>BrandName</td>
</tr>
</table>

<table>
<tr >
<td colspan = "6">Cards </td>
</tr>
<tr><td>CardId</td>
<td>NameOnTheCard</td>
<td>CardNumber</td>
<td>CardCvv</td>
<td>ExpirationDate</td>
<td>MoneyInTheCard</td>
</tr>
</table>

<table>
<tr >
<td colspan = "4">CarImages </td>
</tr>
<tr><td>CarImageId</td>
<td>CarId</td>
<td>ImagePath</td>
<td>Date</td>
</tr>
</table>

<table>
<tr >
<td colspan = "7">Cars </td>
</tr>
<tr><td>CardId</td>
<td>BrandId</td>
<td>ColorId</td>
<td>ModelYear</td>
<td>DailyPrice</td>
<td>Description</td>
<td>CarFindex</td>
</tr>
</table>

<table>
<tr >
<td colspan = "2">Colors </td>
</tr>
<tr><td>ColorId</td>
<td>ColorName</td>
</tr>
</table>

<table>
<tr >
<td colspan = "4">Customers </td>
</tr>
<tr><td>CustomerId</td>
<td>UserId</td>
<td>CompanyName</td>
<td>CustomerFindex</td>
</tr>
</table>

<table>
<tr >
<td colspan = "2">OperationClaims </td>
</tr>
<tr><td>Id</td>
<td>Name</td>
</tr>
</table>

<table>
<tr >
<td colspan = "5">Rentals </td>
</tr>
<tr><td>RentalId</td>
<td>CarId</td>
<td>CustomerId</td>
<td>RentDate</td>
<td>ReturnDate</td>
</tr>
</table>

<table>
<tr >
<td colspan = "3">UserOperationClaims </td>
</tr>
<tr><td>Id</td>
<td>UserId</td>
<td>OperationClaimId</td>
</tr>
</table>


<table>
<tr >
<td colspan = "7">Users</td>
</tr>
<tr><td>Id</td>
<td>FirstName</td>
<td>LastName</td>
<td>Email</td>
<td>PasswordHash</td>
<td>PasswordSalt</td>
<td>Status</td>
</tr>
</table>

