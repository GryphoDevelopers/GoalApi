import { AuthModel } from '../models/api/auth/auth-model';
import { tryParse } from '../extensions/utils/tryParse';
import { Core } from './core';
import express from 'express'
export class AuthController extends Core {
    public async Auth(req: express.Request, res: express.Response) {
        return this.unauthorized(res)
    }
    public async authenticate(req: express.Request, res: express.Response) {
        const { obj, isValid, getErrors } = tryParse<AuthModel>(JSON.stringify(req.body))
        res.send(obj)
    }
}