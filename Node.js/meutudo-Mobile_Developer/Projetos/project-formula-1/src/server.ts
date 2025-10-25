
import fastify from "fastify";
import cors from "@fastify/cors";

const server = fastify({ logger: true });

server.register(cors, {
  origin: "*",
});

const teams = [
  { id: 1, name: "McLaren", base: "Woking, United Kingdom" },
  { id: 2, name: "Ferrari", base: "Maranello, Italy" },
  { id: 3, name: "Mercedes", base: "Brackley, United Kingdom" },
  { id: 4, name: "Red Bull Racing", base: "Milton Keynes, United Kingdom" },
  { id: 5, name: "Williams", base: "Grove, United Kingdom" },
  { id: 6, name: "Aston Martin", base: "Silverstone, United Kingdom" },
  { id: 7, name: "Racing Bulls", base: "Milton Keynes, United Kingdom" }, 
  { id: 8, name: "Kick Sauber", base: "Hinwil, Switzerland" },       
  { id: 9, name: "Haas", base: "Kannapolis, United States" },
  { id: 10, name: "Alpine", base: "Enstone, United Kingdom" }
];


const drivers = [
  { id: 1, name: "Oscar Piastri", team: "McLaren" },
  { id: 2, name: "Lando Norris", team: "McLaren" },
  { id: 3, name: "Charles Leclerc", team: "Ferrari" },
  { id: 4, name: "Lewis Hamilton", team: "Ferrari" },
  { id: 5, name: "George Russell", team: "Mercedes" },
  { id: 6, name: "Kimi Antonelli", team: "Mercedes" },
  { id: 7, name: "Max Verstappen", team: "Red Bull Racing" },
  { id: 8, name: "Yuki Tsunoda", team: "Red Bull Racing" },
  { id: 9, name: "Alexander Albon", team: "Williams" },
  { id: 10, name: "Carlos Sainz", team: "Williams" },
  { id: 11, name: "Lance Stroll", team: "Aston Martin" },
  { id: 12, name: "Fernando Alonso", team: "Aston Martin" },
  { id: 13, name: "Liam Lawson", team: "Racing Bulls" },
  { id: 14, name: "Isack Hadjar", team: "Racing Bulls" },
  { id: 15, name: "Nico Hulkenberg", team: "Kick Sauber" },
  { id: 16, name: "Gabriel Bortoleto", team: "Kick Sauber" },
  { id: 17, name: "Esteban Ocon", team: "Haas" },
  { id: 18, name: "Oliver Bearman", team: "Haas" },
  { id: 19, name: "Pierre Gasly", team: "Alpine" },
  { id: 20, name: "Franco Colapinto", team: "Alpine" },
];


server.get("/teams", async (request, response) => {
  response.type("application/json").code(200);
  return { teams };
});

server.get("/drivers", async (request, response) => {
  response.type("application/json").code(200);
  return { drivers };
});

interface DriverParams {
  id: string;
}

server.get<{ Params: DriverParams }>("/drivers/:id", async (request, response) => {
    const id = parseInt(request.params.id);
    const driver = drivers.find((d) => d.id === id);

    if (!driver) {
      response.type("application/json").code(404);
      return { message: "Driver Not Found" };
    } else {
      response.type("application/json").code(200);
      return { driver };
    }
  }
);

const port = Number(process.env.PORT);
server.listen({ port }, () => {
  console.log("Server init");
});

    