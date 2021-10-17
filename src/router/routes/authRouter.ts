import express from 'express'
import { useAuthController } from '../../controllers'
export const authRouter = express.Router()
authRouter.post('/authenticate', (req, res) => {
    useAuthController.authenticate(req, res);
})

