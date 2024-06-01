// <snippet_UsingModels>
using AARP_BE.Models;
// </snippet_UsingModels>
// <snippet_UsingServices>
using AARP_BE.Services;
// </snippet_UsingServices>

// <snippet_AddControllers>
// <snippet_BooksService>
// <snippet_BookStoreDatabaseSettings>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ResidenceAdministratorDatabaseSettings>(
    builder.Configuration.GetSection("AARPDB"));
// </snippet_BookStoreDatabaseSettings>

builder.Services.AddSingleton<RentalUnitService>();
builder.Services.AddSingleton<AccountService>();
builder.Services.AddSingleton<AddressService>();
builder.Services.AddSingleton<ServiceService>();
builder.Services.AddSingleton<AppPaymentService>();
builder.Services.AddSingleton<ClientService>();
builder.Services.AddSingleton<DiscountService>();
builder.Services.AddSingleton<HolderService>();
builder.Services.AddSingleton<LogService>();
builder.Services.AddSingleton<MoneyTransactionService>();
builder.Services.AddSingleton<OwedDetailService>();
builder.Services.AddSingleton<OwnerService>();
builder.Services.AddSingleton<PaymentService>();
builder.Services.AddSingleton<PeripheralService>();
builder.Services.AddSingleton<PeripheralsTypeService>();
builder.Services.AddSingleton<PermissionService>();
builder.Services.AddSingleton<PettyCashService>();
builder.Services.AddSingleton<RecordService>();
builder.Services.AddSingleton<RentalComplexService>();
builder.Services.AddSingleton<RentalComplexDebtStateService>();
builder.Services.AddSingleton<RentalUnitDebtStateService>();
builder.Services.AddSingleton<RentalUnitPaymentService>();
builder.Services.AddSingleton<ResidentService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<UserTypeService>();
builder.Services.AddSingleton<ResidencesModuleService>();
builder.Services.AddSingleton<ServiceTypeService>();
builder.Services.AddSingleton<AdminControlPanelModuleService>();


// </snippet_BooksService>

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// </snippet_AddControllers>

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
