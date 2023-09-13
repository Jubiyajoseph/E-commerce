import { Data } from "@angular/router";

export interface IorderDetails {
    orderId:number;
    orderedOn:Date;
    totalPrice:number;
    productName:string;
    statusName:string;
}
