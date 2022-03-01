import MatchedBoxModel from './MatchedBoxModel';

export default class {
    id = '';
    name = '';
    pictureUrl: Array<string> = [];
    signatureUrl: Array<string> = [];
    selfIntroduction = '';
    slogan = '';
    likeStyle = '';
    createdDate = '';
    creator = '';
    modifyDate = '';
    modifier = '';
    matchingCounts: Array<MatchedBoxModel> = [];
}
