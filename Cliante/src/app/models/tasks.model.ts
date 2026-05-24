
export class Tasks{
    id!: number
    name!: string
    description!:string
    status?:string
    dueDate!: Date
    grade!:eGradeLevelTesk
}

export enum eGradeLevelTesk{
  a="A",b="B",c="C"
}
