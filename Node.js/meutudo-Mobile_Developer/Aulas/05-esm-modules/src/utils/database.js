 const databaseType = {
    userType: "admin",
    typeData: "dataLocal"
 };

async function connectToDatabase(dataName) {
    // lógica de conexão
    console.log(`conectando ao banco ${dataName}`);
}

async function disconnectDatabase() {
    console.log("desconectando banco de dados")
}

// exportando apenas uma função
//export default connectToDatabase;

// exportando mais de uma função
export { connectToDatabase, disconnectDatabase, databaseType };