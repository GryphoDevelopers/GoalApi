import { Column, Entity, OneToMany } from 'typeorm'
import { System } from '..';
import { Address } from './Address';
@Entity("user")
export class User extends System{
    @Column("varchar")
    name!: string
    @Column("varchar")
    surname!: string
    @Column("varchar")
    password!: string
    @Column("varchar")
    phone! : string
    @Column("varchar")
    email!: string
    @OneToMany(() => Address, address => address.user)
    address!: Address[]
}