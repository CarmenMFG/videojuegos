import { SystemModel } from './system.model';
import { SupportModel } from './support.model';
import { PlatformModel } from './platform.model';
export class VideoGameModel {
    public title: string;
    public developer: string;
    public barCode: string;
    public redump: string;
    public genre: string;
    public distributor: string;
    public region: string;
    public language: string;
    public notes: string;
    public description: string;
    public idSystem: number;
    public idSupport: number;
    public coverPage: string;
    public releaseDate: Date;
   // public backCover: string;
    public id: number;
    public systems: SystemModel;
    public platform: PlatformModel;
    public support: SupportModel;
    public isNew: boolean;

}
