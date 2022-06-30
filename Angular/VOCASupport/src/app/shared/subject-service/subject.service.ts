import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  private messegeSource = new BehaviorSubject<string>("");
  currentmessege =this.messegeSource.asObservable();

  constructor() { }
  changeMessege(messege:string){
    this.messegeSource.next(messege);
  }
}
