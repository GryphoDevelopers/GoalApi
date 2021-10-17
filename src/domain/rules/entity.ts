import { Column, Entity, PrimaryColumn, PrimaryGeneratedColumn } from 'typeorm'

export class System {
    @PrimaryColumn("uuid")
    id!: string;
    @PrimaryColumn("boolean")
    isDeleted!: boolean;
}