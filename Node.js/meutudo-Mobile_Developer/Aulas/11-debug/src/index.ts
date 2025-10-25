import { getBaseEmail } from "./services/email";

async function main() {
  console.log(await getBaseEmail("João"));

  console.log("finalizado");
  console.log("...");
}

main()
