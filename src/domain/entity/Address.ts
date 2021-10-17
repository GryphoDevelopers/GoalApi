import { Column, Entity, ManyToOne } from 'typeorm'
import { User } from './User';
import { System } from '..';

@Entity("address")
export class Address extends System {
    @Column('varchar')
    number!: string
    @Column('int')
    postalCode!: string
    @Column('varchar')
    country!: string
    @Column('varchar')
    state!: string
    @Column('varchar')
    complement!: string
    @Column('varchar')
    district!: string
    @Column('varchar')
    street!: string
    @ManyToOne(() => User, user => user.address)
    user!: User
}