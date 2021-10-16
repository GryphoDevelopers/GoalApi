import { Column, Entity, PrimaryColumn, PrimaryGeneratedColumn } from 'typeorm'
@Entity("user")
export class User {
    @PrimaryColumn("uuid")
    id! : string;
    @Column("varchar")
    name! : string
}