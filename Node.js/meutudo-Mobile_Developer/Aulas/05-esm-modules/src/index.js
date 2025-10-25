//import connectToDatabase from "./utils/database.js"
import { disconnectDatabase, databaseType } from "./utils/database.js"; 
import {getDataFromApi} from './utils/api.js'
import * as api from "./utils/api.js"

getDataFromApi();
api.getDataFromApi()
disconnectDatabase();
api.teste();
await api.testeAsync();

let result = api.soma1(1,2,4);
console.log(result)
