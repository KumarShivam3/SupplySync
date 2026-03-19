using Microsoft.EntityFrameworkCore;
using SupplySync.Config;
using SupplySync.Middleware;
using SupplySync.Repositories;
using SupplySync.Repositories.Interfaces;
using SupplySync.Services;
using SupplySync.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// DB CONTEXT
// --------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));
<<<<<<< Updated upstream



builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();



=======

>>>>>>> Stashed changes
// --------------------
// AUTOMAPPER
// --------------------
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// --------------------
// REPOSITORIES
// --------------------
builder.Services.AddScoped<IComplianceRecordRepository, ComplianceRecordRepository>();
builder.Services.AddScoped<IAuditRepository, AuditRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
<<<<<<< Updated upstream
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();


=======
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

>>>>>>> Stashed changes
// --------------------
// SERVICES
// --------------------
builder.Services.AddScoped<IComplianceRecordService, ComplianceRecordService>();
builder.Services.AddScoped<IAuditService, AuditService>();
builder.Services.AddScoped<IReportService, ReportService>();
<<<<<<< Updated upstream
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IContractService, ContractService>();
=======
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
>>>>>>> Stashed changes

// --------------------
// CONTROLLERS & API
// --------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// --------------------
// PIPELINE
// --------------------
<<<<<<< Updated upstream
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

=======
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ErrorHandlingMiddleware>();
>>>>>>> Stashed changes

app.Run();

