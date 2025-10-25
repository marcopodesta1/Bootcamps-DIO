export const key = {
    value: "2313jklfds",
    permission: "admin"
};

export const getDataFromApi = () => {
    console.log("dados da sendo buscados...");
};

export function teste(){
    console.log("teste de exportação de função")
}

export async function testeAsync(){
    console.log("teste de exportação de função assíncrona")
}

export const soma1 = (n1, n2, n3) => {
   return n1+n2+n3;
}

export function soma(n1, n2){
    return n1+n2;
}