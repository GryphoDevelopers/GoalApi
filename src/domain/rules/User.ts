import {
  Sequelize,
  Model,
  Optional,
  DataTypes,
} from "sequelize";

interface UserAttributes {
  id: number;
  name: string;
  preferredName: string | null;
}


// const sequelize = databaseConnect()

interface UserCreationAttributes extends Optional<UserAttributes, "id"> { }

class SUser extends Model<UserAttributes, UserCreationAttributes>
  implements UserAttributes {
  public id!: number; // Note that the `null assertion` `!` is required in strict mode.
  public name!: string;
  public preferredName!: string | null; // for nullable fields
}

SUser.init(
  {
    id: {
      type: DataTypes.INTEGER.UNSIGNED,
      autoIncrement: true,
      primaryKey: true,
    },
    name: {
      type: new DataTypes.STRING(128),
      allowNull: false,
    },
    preferredName: {
      type: new DataTypes.STRING(128),
      allowNull: false,
    },
  },
  {
    sequelize,
    tableName: "projects",
  }
);