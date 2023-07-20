import { Component } from '@angular/core';
import { ServiceService } from '../service.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent {
  constructor(private service:ServiceService){}
name:any;
dataSource:any
displayedColumns:string[]=['Employee Id','Employee Name','Email', 'DOB', 'city','Phone']
ngOnInit()
{
 this.name=localStorage.getItem("displayname")
this.GetAll()

}
GetAll()
{
  this.service.GetEmployee().subscribe((res:any)=>
  {
      console.log(res.dataList);
      if(res.dataList!=null)
      {
        this.dataSource=new MatTableDataSource<any>(res.dataList)
      }
      
  })
  
}
}
