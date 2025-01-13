using PruebasAPIBlazor.Context;
using PruebasAPIBlazor.Models;
using System.Drawing;

namespace PruebasAPIBlazor.Helpers
{
    public class DbService
    {
        public ApplicationDbContext _context { get; set; }

        public ConfigurationManager _configuration { get; set; }

        public AuthenticationService _authenticationService { get; set; }

        public DbService(ApplicationDbContext context, ConfigurationManager configuration, AuthenticationService authenticationService)
        {
            _context = context;
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        public void SeedUsuarios()
        {
            if (!_context.Usuarios.Any())
            {
                Usuario usuario = new Usuario()
                {
                    Id = 0,
                    Email = "admin@admin.com",
                    Contraseña = _authenticationService.Encrypt("admin2024", _configuration.GetSection("Salt").Value),
                    Verificado = true
                };
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
        }

        public void SeedRecetas()
        {
            if (!_context.Recetas.Any())
            {
                ImageConverter conversor = new ImageConverter();
                List<Receta> recetas = new List<Receta>() {
                    new Receta()
                    {
                        Id = 0,
                        IdAutor = _context.Usuarios.First().Id,
                        NombreReceta = "Rollitos de primavera",
                        Ingredientes = "Pasta filo;2 dientes de ajo;Una cucharada de cebolla verde;Media cucharada de jengibre;Una zanahoria;Media col;Media cebolla;250gr carne picada de cerdo;Sal y pimienta al gusto",
                        Descripcion = "Empezamos dorando ligeramente el ajo y el jengibre. Una vez dorados, añadimos el resto de verduras, y cocinamos hasta que están blandas.\r\nTras ello, añadimos la carne picada de cerdo, y cocinamos hasta que esté prácticamente hecha. Vamos corrigiendo de sal y pimienta a nuestro gusto\r\nDejamos enfriar el relleno que hemos hecho durante unos minutos, y rellenamos las hojas de pasta filo. Con cuidado, las enrollamos y les damos la forma de los clásicos rollitos. Si no lográis cerrarlos, añadid unas gotitas de agua al borde de la masa, donde la vamos a cerrar. Freir durante un minuto o hasta que la masa esté ligeramente dorada.\r\n¡Y ya estaría! Ya podemos disfrutar de unos rollitos de primavera caseros",
                        Tiempo = 30,
                        Categoria = Categoria.Cena,
                        Dificultad = Dificultad.Normal,
                        Imagen = "https://live.staticflickr.com/3003/2930449457_11abc203ba_b.jpg"
                    },
                    new Receta()
                    {
                        Id = 0,
                        IdAutor = _context.Usuarios.First().Id,
                        NombreReceta = "Cookies de chocolate",
                        Ingredientes = "200gr de harina;2 huevos;100gr de azúcar;120gr de mantequilla;100gr de pepitas de chocolate;1 cucharadita de levadura;Media cucharadita de sal",
                        Descripcion = "Empezamos mezclando los huevos con el azúcar, hasta que la mezcla haya blanqueado ligeramente. Tras ello, añadimos la mantequilla en pomada y la integramos.\r\nUna vez integrados los anteriores ingredientes, agregamos la harina tamizada poco a poco y vamos mezclando. Añadimos también la levadura y la pizca de sal.\r\nFinalmente, añadimos las pepitas de chocolate, y mezclamos por última vez. Damos forma cilíndrica a la masa en film transparente, y dejamos endurecer la masa en la nevera mínimo media hora.\r\nUna vez endurecida la masa, la cortamos en porciones, la aplastamos ligeramente en forma circular, y la ponemos en una bandeja de horno con papel sulfurizado.\r\nPrecalentamos el horno a 180º y horneamos durante media hora.\r\nRetiramos una vez pasado el tiempo, ¡Y ya tenemos nuestras cookies caseras!",
                        Tiempo = 90,
                        Categoria = Categoria.Desayuno,
                        Dificultad = Dificultad.Fácil,
                        Imagen = "https://live.staticflickr.com/3353/4643536339_040a11812c_b.jpg"
                    },
                    new Receta()
                    {
                        Id = 0,
                        IdAutor = _context.Usuarios.First().Id,
                        NombreReceta = "Patatas fritas",
                        Ingredientes = "Aceite;Patatas;Una pizca de sal",
                        Descripcion = "Cortamos las patatas en rodajas lo más finas posibles. Les escurrimos el exceso de agua, colocándolas sobre papel de cocina.\r\nPreparamos una sartén con aceite (¡el tipo de aceite, a gusto tuyo!), y freimos las patatas a fuego fuerte. Una vez fritas, escurrir el exceso de aceite, y echar sal al gusto.\r\n¡Y ya tenemos nuestras patatas fritas! Una receta fácil de preparar, y que lleva muy poco tiempo",
                        Tiempo = 15,
                        Categoria = Categoria.Picoteo,
                        Dificultad = Dificultad.Fácil,
                        Imagen = "https://live.staticflickr.com/2734/4112877207_794109426a_b.jpg"
                    },
                    new Receta()
                    {
                        Id = 0,
                        IdAutor = _context.Usuarios.First().Id,
                        NombreReceta = "Pizza casera",
                        Ingredientes = "400gr harina de trigo;50gr harina de maíz;250gr de agua tibia;50gr de aceite;8gr de levadura fresca;Sal al gusto;Toppings al gusto",
                        Descripcion = "En un bol, mezclamos los dos tipos de harina. Hacemos un agujero en medio de la masa, diluimos la levadura fresca en el agua y lo vertemos en el agujero que hemos hecho. Dejamos que la levadura actúe durante 10 minutos.\r\nTras ello, incorporamos el aceite, y comenzamos a amasar. Tras amasar un poco, agregamos la sal, y terminamos de amasar. Volvemos a pasar la masa ya amasada al bol, y dejamos que repose durante al menos una hora.\r\nUna vez reposada la masa, la estiramos sobre una bandeja de horno con papel sulfurizado, y le agregamos nuestros ingredientes preferidos.\r\nPrecalentamos el horno a 180º, metemos la pizza y horneamos durante 15-20 minutos.\r\n¡Listo! Hemos hecho una pizza casera, sana y deliciosa.",
                        Tiempo = 120,
                        Categoria = Categoria.Cena,
                        Dificultad = Dificultad.Normal,
                        Imagen = "https://live.staticflickr.com/3579/3321964027_89ca1f85f7_b.jpg"
                    },
                    new Receta()
                    {
                        Id = 0,
                        IdAutor = _context.Usuarios.First().Id,
                        NombreReceta = "Nuggets de pollo",
                        Ingredientes = "Harina de trigo;Una pechuga de pollo;Aceite;Sal y especias al gusto",
                        Descripcion = "Cortamos la pechuga en figuras de unos 1.5cm de grosor. Les añadimos las especias que más nos gusten, sal al gusto, y enharinamos.\r\nEn una sartén con abundante aceite, freímos hasta que los nugget estén dorados.\r\n¡Y ya tenemos nuestros nuggets caseros!",
                        Tiempo = 10,
                        Categoria = Categoria.Picoteo,
                        Dificultad = Dificultad.Fácil,
                        Imagen = "https://live.staticflickr.com/2148/1728698209_f8a962661a_c.jpg"
                    },
                    new Receta()
                    {
                        Id = 0,
                        IdAutor = _context.Usuarios.First().Id,
                        NombreReceta = "Tortitas de trigo",
                        Ingredientes = "120gr de harina de trigo;80gr de azúcar;40gr de mantequilla;25gr de leche;Un huevo;Un cucharadita de levadura;Toppings al gusto",
                        Descripcion = "Meclamos todos los ingredientes en un vaso medidor, y dejamos reposar la mezcla durante al menos 10 minutos.\r\nEn una sartén con un poco de mantequilla derretida, y a fuego medio/bajo, añadimos un poco de la mezcla. Cocinamos hasta que veamos que aparecen burbujitas, y le damos la vuelta para terminar de cocinarla por el otro lado (un minuto como mucho más). Las retiramos de la sartén, y las vamos apilando en un plato.\r\nFinalmente, añadimos los toppings que prefiramos (chocolate, siropes, fruta, etc...) ¡y a disfrutar de nuestras tortitas caseras!",
                        Tiempo = 25,
                        Categoria = Categoria.Merienda,
                        Dificultad = Dificultad.Normal,
                        Imagen = "https://live.staticflickr.com/3418/3719644155_8a02ddb48e_b.jpg"
                    },
                    new Receta()
                    {
                        Id = 0,
                        IdAutor = _context.Usuarios.First().Id,
                        NombreReceta = "Solomillo Wellington",
                        Ingredientes = "Masa de hojaldre;Una bandeja de champiñones;Un solomillo de cerdo;Unas lonchas de bacon;Un huevo;Sal y pimienta al gusto",
                        Descripcion = "Comenzamos cocinando los champiñones en una sartén a fuego medio. Una vez estén blandos, los pasamos a un vaso medidor, y los pasamos por la batidora, hasta convertirlos en puré. Reservamos este puré.\r\nSalpimentamos el solomillo, y en otra sartén, lo sellamos por todos sus lados.\r\nEstiramos la masa de hojaldre, y extendemos el puré de champiñones que hemos creado previamante sobre la masa. Sobre el puré de championes, colocamos las lonchas de bacon. Una vez extendidas, colocamos el solomillo. Cerramos la masa por todos los lados con cuidado, y pintamos con huevo.\r\nPrecalentamos el horno a 180º, y horneamos el solomillo durante una hora aproximadamente.\r\nRetiramos del horno, ¡y ya tenemos nuestro solomillo Wellington casero!",
                        Tiempo = 120,
                        Categoria = Categoria.Comida,
                        Dificultad = Dificultad.Difícil,
                        Imagen = "https://upload.wikimedia.org/wikipedia/commons/8/8b/Solomillo_wellington.jpg"
                    },

                };
                _context.Recetas.AddRange(recetas);
                _context.SaveChanges();
            }
        }

    }
}
