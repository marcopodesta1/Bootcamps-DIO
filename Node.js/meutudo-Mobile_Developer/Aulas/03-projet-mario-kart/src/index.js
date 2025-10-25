const players = [
    { NOME: "Mario", VELOCIDADE: 4, MANOBRABILIDADE: 3, PODER: 3, PONTOS: 0, },
    { NOME: "Luigi", VELOCIDADE: 3, MANOBRABILIDADE: 4, PODER: 4, PONTOS: 0, },
    { NOME: "Peach", VELOCIDADE: 3, MANOBRABILIDADE: 4, PODER: 2, PONTOS: 0, },
    { NOME: "Yoshi", VELOCIDADE: 2, MANOBRABILIDADE: 4, PODER: 3, PONTOS: 0, },
    { NOME: "Bowser", VELOCIDADE: 5, MANOBRABILIDADE: 2, PODER: 5, PONTOS: 0, },
    { NOME: "Donkey Kong", VELOCIDADE: 2, MANOBRABILIDADE: 2, PODER: 5, PONTOS: 0, },
];

async function choosePlayers() {
    let indexPlayer1 = Math.floor(Math.random() * 6);
    let indexPlayer2;
    do {
        indexPlayer2 = Math.floor(Math.random() * 6);
    }
    while (indexPlayer1 === indexPlayer2);

    return [players[indexPlayer1], players[indexPlayer2]];
}

async function rollDice() {
    return Math.floor(Math.random() * 6) + 1;
}

async function getRandomBlock() {
    let random = Math.random();
    let result;

    switch (true) {
        case random < 0.33:
            result = "Reta";
            break;
        case random < 0.66:
            result = "Curva";
            break;
        default:
            result = "Confronto";
            break;
    }
    return result;
}

async function logRollResult(characterName, block, diceResult, attribute) {
    console.log(`${characterName} 🎲 rolou um dado de ${block} ${diceResult} + ${attribute} = ${diceResult + attribute}`);
}

async function playRaceEngine(character1, character2) {
    for (let round = 1; round <= 5; round++) {
        console.log(`🏁 Rodada ${round}`);

        //sortar bloco
        let block = await getRandomBlock();
        console.log(`Bloco: ${block}`);

        //rolar os dados
        let diceResult1 = await rollDice()
        let diceResult2 = await rollDice()

        //teste de habilidade
        let totalTestSkill1 = 0;
        let totalTestSkill2 = 0;

        if (block === "Reta") {
            totalTestSkill1 = diceResult1 + character1.VELOCIDADE;
            totalTestSkill2 = diceResult2 + character2.VELOCIDADE;
            await logRollResult(character1.NOME, "velocidade", diceResult1, character1.VELOCIDADE);
            await logRollResult(character2.NOME, "velocidade", diceResult2, character2.VELOCIDADE);
        }
        else if (block === "Curva") {
            totalTestSkill1 = diceResult1 + character1.MANOBRABILIDADE;
            totalTestSkill2 = diceResult2 + character2.MANOBRABILIDADE;
            await logRollResult(character1.NOME, "manobrabilidade", diceResult1, character1.MANOBRABILIDADE);
            await logRollResult(character2.NOME, "manobrabilidade", diceResult2, character2.MANOBRABILIDADE);
        }
        else if (block === "Confronto") {
            let powerResult1 = diceResult1 + character1.PODER;
            let powerResult2 = diceResult2 + character2.PODER;
            console.log(`${character1.NOME} confrontou com ${character2.NOME}! 🥊`)
            await logRollResult(character1.NOME, "poder", diceResult1, character1.PODER);
            await logRollResult(character2.NOME, "poder", diceResult2, character2.PODER);

            let pointsToLose = Math.floor(Math.random() * 2) + 1;
            let img = pointsToLose === 1 ? "casco 🐢" : "bomba 💣";
            let winTurbo = Math.floor(Math.random() * 2) === 1 ? true : false;

            if (powerResult1 > powerResult2 && character2.PONTOS >= pointsToLose) {
                console.log(`Foi sorteado ${img}!`)
                console.log(`${character1.NOME} venceu o confronto! ${character2.NOME} perdeu ${pointsToLose} ponto(s) ${img}`);
                if (winTurbo) {
                    console.log(`${character1.NOME} ganhou, aleatoriamente, um turbo (+1 ponto) 🚀 `)
                    character1.PONTOS++
                }
                character2.PONTOS -= pointsToLose;
            }
            else if (powerResult2 > powerResult1 && character1.PONTOS >= pointsToLose) {
                console.log(`Foi sorteado ${img}!`)
                console.log(`${character2.NOME} venceu o confronto! ${character1.NOME} perdeu ${pointsToLose} ponto(s) ${img}`);
                if (winTurbo) {
                    console.log(`${character2.NOME} ganhou, aleatoriamente, um turbo (+1 ponto) 🚀 `)
                    character1.PONTOS++
                }
                character1.PONTOS -= pointsToLose;
            }
            else if (powerResult1 === powerResult2)
                console.log("Confronto empatado! Nenhum ponto foi perdido!");
        }

        //verificando o vencedor
        if (totalTestSkill1 > totalTestSkill2) {
            console.log(`${character1.NOME} marcou um ponto!`);
            character1.PONTOS++;
        }
        else if (totalTestSkill2 > totalTestSkill1) {
            console.log(`${character2.NOME} marcou um ponto!`);
            character2.PONTOS++;
        }
        console.log("----------------------------------------------------");
    }
}

async function declareWinner(character1, character2) {
    console.log("Resultado final:");
    console.log(`${character1.NOME}: ${character1.PONTOS} ponto(s)`);
    console.log(`${character2.NOME}: ${character2.PONTOS} ponto(s)`);

    if (character1.PONTOS > character2.PONTOS)
        console.log(`\n${character1.NOME} venceu a corrida! Parabéns! 🏆`);
    else if (character2.PONTOS > character1.PONTOS)
        console.log(`\n${character2.NOME} venceu a corrida! Parabéns! 🏆`);
    else
        console.log("\nAcorrida terminou em empate");
}

// função auto-invocável
(async function main() {
    let choosenPlayers = await choosePlayers();
    let player1 = choosenPlayers[0];
    let player2 = choosenPlayers[1];
    console.log(`🏁🚨 Corrida entre ${player1.NOME} e ${player2.NOME} começando...\n`);
    await playRaceEngine(player1, player2);
    await declareWinner(player1, player2);

})();

