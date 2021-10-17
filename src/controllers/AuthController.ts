import { AuthModel } from '../models/api/auth/auth-model';
import express from 'express'
import { Core } from './core';
import { tryParse } from '../extensions/utils/tryParse';
export class AuthController extends Core {
    public async Auth(req: express.Request, res: express.Response) {
        return this.unauthorized(res)
    }
    public async authenticate(req: express.Request, res: express.Response) {
        const { getErrors, obj, isValid } = tryParse<AuthModel>(AuthModel, req.body)
        if(!isValid()){
            this.addErrors(getErrors())
            return this.ApiResponse(req, res, 400)
        }
        else{
            res.send(getErrors())  
        }
    }
}