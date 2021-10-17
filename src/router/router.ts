import express from 'express'
import { useAuthController } from '../controllers';
export const router = express.Router();
router.get('/teste', (req, res) => {
    useAuthController.Auth(req, res)
})


