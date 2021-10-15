import { stringEmpty } from "../../extensions/utils/stringEmpty";
export class databaseAuthModel{
    constructor(
        public databaseName: string = stringEmpty(),
        public databaseHost: string = stringEmpty(),
        public databaseUser: string = stringEmpty(),
        public databasePassword: string = stringEmpty(),
    ){}
}