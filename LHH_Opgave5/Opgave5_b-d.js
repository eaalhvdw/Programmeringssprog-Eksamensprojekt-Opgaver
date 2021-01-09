/*
    Delopgave b

    Beregn drengenes og pigernes karaktergennemsnit.
 */
console.log("Opgave b");

const grades = [
    { name: "Peter", grade: 7, sex: "M" },
    { name: "Susanne", grade: 12, sex: "F" },
    { name: "Birger", grade: 10, sex: "M" },
    { name: "Jens", grade: 2, sex: "M" },
    { name: "Edar", grade: 4, sex: "M" },
    { name: "Pauline", grade: 12, sex: "F" },
    { name: "Dennis", grade: 2, sex: "M" },
    { name: "Jane", grade: 4, sex: "F" },
    { name: "Cecilie", grade: 10, sex: "F" },
    { name: "Jessica", grade: 4, sex: "F" }
]

const isBoy = grades => grades.sex === "M";
const isGirl = grades => grades.sex === "F";

const boys = grades.filter(isBoy);
const girls = grades.filter(isGirl);

const boysSumGrades = boys.reduce((sum, boy) => sum + boy.grade, 0);
const boysAverageGrade = boysSumGrades / boys.length;

const girlsSumGrades = girls.reduce((sum, girl) => sum + girl.grade, 0);
const girlsAverageGrade = girlsSumGrades / girls.length;

console.log("Drengenes karaktergennemsnit er", boysAverageGrade);
console.log("Pigernes karaktergennemsnit er", girlsAverageGrade);
console.log();

// ------------------------------------------------------------------------------------------ //

/*
    Delopgave c

    Beregn den samlede indtægt for de mandlige skakspillere.
 */
console.log("Opgave c");

const players = [
    { id: 1, player: "Dennis", game: "Chess", sex: "M", earnings: 86001, score: 2009 },
    { id: 2, player: "Brian", game: "Running", sex: "M", earnings: 120000, score: 23 },
    { id: 3, player: "Dorte", game: "Chess", sex: "F", earnings: 1200, score: 1903 },
    { id: 4, player: "Hanne", game: "Curling", sex: "F", earnings: 123000, score: 142 },
    { id: 5, player: "Charlotte", game: "Curling", sex: "F", earnings: 87000, score: 150 },
    { id: 6, player: "Jens", game: "Chess", sex: "M", earnings: 14000, score: 1958 },
    { id: 7, player: "Victor", game: "Curling", sex: "M", earnings: 100000, score: 2 },
    { id: 8, player: "Ethanial", game: "Running", sex: "M", earnings: 100, score: 23 },
    { id: 9, player: "Vibeke", game: "Chess", sex: "F", earnings: 10, score: 1450 }
]

const isManAndChessPlayer = players => players.sex === "M" && players.game === "Chess";

const totalEarningsOfChessPlayingMen = players.filter(isManAndChessPlayer)
    .reduce((sum, chessPlayer) => sum + chessPlayer.earnings, 0);

console.log("Den samlede indtægt for de mandlige skakspillere er",
    totalEarningsOfChessPlayingMen);
console.log();

// ------------------------------------------------------------------------------------------ //

/*
    Delopgave d

    Skriv et program, der for navnene Douglas og Adams, eksekverer de tilhørende funktioner,
    "executor", og summerer resultaterne, startende fra defaultværdien 0.
 */
console.log("Opgave d");

const peopleData = [
    { name: "H.C.", salary: 1200, id: 1, executor: num => num + num * 0.25 },
    { name: "Andersen", salary: 130, id: 2, executor: num => num + 1 },
    { name: "Douglas", salary: 90, id: 3, executor: num => num + 1 },
    { name: "Ditlevsen", salary: 150, id: 4, executor: num => num + 10 },
    { name: "Ian", salary: 120000, id: 5, executor: num => num * 10 },
    { name: "Flemmings", salary: 9000, id: 6, executor: num => num + 15 },
    { name: "Adams", salary: 100, id: 7, executor: num => num + 15 },
    { name: "Tove", salary: 190, id: 8, executor: num => num + 10 },
    { name: "Douglas", salary: 12000, id: 9, executor: num => num + 15 },
    { name: "Ian", salary: 120000, id: 10, executor: num => num * 20 },
    { name: "Flemmings", salary: 9000, id: 11, executor: num => num + 1 },
    { name: "Adams", salary: 100, id: 12, executor: num => num + 10 },
    { name: "Ditlevsen", salary: 190, id: 13, executor: num => num + 10 },
    { name: "Douglas", salary: 12000, id: 14, executor: num => num + 1 }
]

const isDouglasOrAdams = peopleData => peopleData.name === "Douglas" ||
    peopleData.name === "Adams";

const douglasAndAdams = peopleData.filter(isDouglasOrAdams);

const executorOnInput = (sum, func) => {
    return func(sum);
}

const result = douglasAndAdams.map(x => x.executor).reduce(executorOnInput, 0);

console.log("De summerede resultater af eksekvering af Douglas' og Adams' executor " +
    "funktioner, med startværdien 0, er", result);

