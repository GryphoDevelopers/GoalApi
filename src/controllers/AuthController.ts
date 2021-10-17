import express from 'express'
import { Core } from './Core';
export class AuthController extends Core{
    public async Auth(req: express.Request, res: express.Response){
        res.send('sus')
    }
}