# Healthcare Provider Appointment Scheduling System Project

Tamamlamış olduğum bu Web API projesinin amacı sağlık sağlayıcılarının hastaların bilgilerini ve randevu sistemini yönetebilmesini sağlamaktır.Geliştirme aşamasında .Net 6 kullanılmıştır.
Database olarak PostgreSQL kullanılmıştır. Code first yaklaşımı ile oluşturulan bu Restfull Web API projesi aynı zamanda bilgilendirme sisteminide barındırmaktadır. Hastalar için randevu 
oluşturulduğunda ve randevu tarihine bir gün kala hastalara bildirim mesajı Email yolu ile iletilmektedir. Bu hizmeti sağlamak için background-worker olarak Hangfire kullanılmıştır.

## Yüklenen Kütüphaneler
-Microsoft.EntityFrameworkCore

-Microsoft.EntityFrameworkCore.Tools

-Npgsql.EntityFrameworkCore.PostgreSQL

-AutoMapper

-AutoMapper.Extensions.Microsoft.DependencyInjection

-Hangfire

-Hangfire.MemoryStorage

-Newtonsoft.Json


Code-First olarak ilerlendiğinden proje indirildikten sonra database ve table oluşumu için Consola aşadaki kod yazılarak çalıştırılıp Db oluşturulmalıdır.

>> Update-Database -Context ApplicationDbContext

Bu aşamadan sonra program çalışınca Swagger entegrasyonunda da göreceğimiz gibi 2 temel controllorımız bulunmaktadır.

-PatientController : Burada temel CRUD işlemleri gerçekleştirilmektedir.Hastanın tıbbı geçmiş öyküsüne ve randevu bilgilerine de buradan erişim sağlayıp 
yönetebildiğimiz endpointler sağlanmıştır.

-AppointmentController :Burada temel CRUD işlemleri gerçekleştirilmektedir.Hastanın randevu bilgilerine de buradan erişim sağlayıp yönetebildiğimiz endpointler sağlanmıştır.

Hangfire proje ayağa kaldırıldığında otomatik olarak çalıştırılacaktır. Her gün sabah 8.30 da bir sonraki gün için oluşturulmuş randevu bilgilerini ilgililere otomatik olarak mail yolu ile göndermektedir.
Hangfire-dashboard url : localhost:xxxx/hf-dashboard şeklinde dashboard üzerinden anlık olarak da tetiklenebilir.

## Swagger

### Controllers

><img src="https://github.com/burcMnt/PatientManagementAndAppointmentSystem_GF/blob/master/PatientManagementAndAppointmentSystem_GF/Images/swgr1.png"/>
><img src="https://github.com/burcMnt/PatientManagementAndAppointmentSystem_GF/blob/master/PatientManagementAndAppointmentSystem_GF/Images/swgr2.png"/>
><img src="https://github.com/burcMnt/PatientManagementAndAppointmentSystem_GF/blob/master/PatientManagementAndAppointmentSystem_GF/Images/swgr3.png"/>

## Hangfire

><img src="https://github.com/burcMnt/PatientManagementAndAppointmentSystem_GF/blob/master/PatientManagementAndAppointmentSystem_GF/Images/hf1.png"/>
><img src="https://github.com/burcMnt/PatientManagementAndAppointmentSystem_GF/blob/master/PatientManagementAndAppointmentSystem_GF/Images/hf2.png"/>