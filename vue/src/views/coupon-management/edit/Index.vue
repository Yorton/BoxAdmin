<template lang="pug">
<div class="pd-5 table">
<el-form class="border-light pd-5 mb-5" ref="formEdit" name="formEdit">
    <el-form-item label="">
        <el-row>
            <el-col :span="8"> 
                <el-button size="medium" type="primary" @click="backToHome">回列表頁</el-button>
            </el-col>
            <el-col :span="8"></el-col>
            <el-col :span="8">
                <el-button size="medium" type="primary" @click="goToDetail" v-if="state.action=='update'">明細</el-button>
            </el-col>
        </el-row>
    </el-form-item> 
    <el-form-item label="">
        <el-row>
            <el-col :span="8"> 
                span.coupon-edit__span_bold Coupon ID 
                span &emsp;
                span {{ `${state.editObj.id}` }} 
            </el-col>
            <el-col :span="8"></el-col>
            <el-col :span="8">
                span.coupon-edit__span_bold 狀態
                span &emsp;
                span {{ `${state.editObj.status}` }} 
            </el-col>
        </el-row>
    </el-form-item>
    <el-form-item label="">
        <el-row>
            <el-col :span="8"> 
                span.coupon-edit__span_bold Coupon 名稱 
                span &emsp;
                el-input.coupon-edit__input_1(v-model="state.editObj.couponName" maxlength="30")
            </el-col>
            <el-col :span="8"></el-col>
            <el-col :span="8">
                span.coupon-edit__span_bold 類型
                span &emsp;
                span {{ `${state.editObj.couponTypeName}` }} 
            </el-col>
        </el-row>
    </el-form-item>
    <el-form-item label="">
        <el-row>
            <el-col :span="8"> 
                span.coupon-edit__span_bold 領取/歸戶方式 
                span &emsp;
                el-select.coupon-edit__select.ob-ml-1(v-model="state.editObj.receiveType" 
                :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==2 || state.editObj.couponType==3 || state.editObj.couponType==4 || state.editObj.couponType==5 || state.editObj.couponType==6))")
                    el-option(v-for="(item, index) in state.receiveTypeOptions" :label="item.label" :value="item.value" :key="`option-${index}`") 
            </el-col>
            <el-col :span="8"></el-col>
            <el-col :span="8">
                span.coupon-edit__span_bold(v-if="state.action=='update' || (state.action=='add' && state.editObj.outputType==1)") 指定碼
                span &emsp;
                el-input.coupon-edit__input_1(v-model="state.editObj.specialCode" maxlength="10" v-if="state.action=='update' || (state.action=='add' && state.editObj.outputType==1)" 
                        :disabled="state.action=='update' && state.editObj.outputType==2" style="width:30%;")
            </el-col>
        </el-row>
    </el-form-item>
    <el-form-item label="">
        <el-row>
            <el-col :span="12"> 
                span.coupon-edit__span_bold 活動時間
                span &emsp;   
                el-date-picker(v-model="state.editObj.marketingActivityStartDate" type="date" value-format="yyyy-MM-dd" style="width:30%;")                          
                span &nbsp;～&nbsp;
                el-date-picker(v-model="state.editObj.marketingActivityEndDate" type="date" value-format="yyyy-MM-dd" style="width:30%;")
            </el-col>
            <el-col :span="12"></el-col>
        </el-row>
    </el-form-item>
    <el-form-item label="">
        <el-row>
            <el-col :span="2">
                span.coupon-edit__span_bold 指定發送時間點
            </el-col>
            <el-col :span="3">
                el-radio-group(v-model="state.editObj.sendTimePoint" style="margin-top: 2%")
                    el-radio(:label="0" style="margin-top: 5%" v-model="state.editObj.sendTimePoint" :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==2 || state.editObj.couponType==3 || state.editObj.couponType==4 || state.editObj.couponType==5 || state.editObj.couponType==6))")
                        span 無
                    el-radio(:label="1" style="margin-top: 5%" v-model="state.editObj.sendTimePoint" :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==2 || state.editObj.couponType==3 || state.editObj.couponType==4))")
                        span 系統自動取用
                    el-radio(:label="2" style="margin-top: 5%" v-model="state.editObj.sendTimePoint" :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==3 || state.editObj.couponType==4 || state.editObj.couponType==5 || state.editObj.couponType==6))")
                        span 每個月1號
                    el-radio(:label="3" style="margin-top: 5%" v-model="state.editObj.sendTimePoint" :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==2 || state.editObj.couponType==5 || state.editObj.couponType==6))")
                        span 訂單成立後1天
            </el-col>
            <el-col :span="11"></el-col>
            <el-col :span="8">
                span.coupon-edit__span_bold 發送條件
                span &emsp;
                el-select.coupon-edit__select.ob-ml-1(v-model="state.editObj.sendCondition" 
                                                      :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==2 || state.editObj.couponType==3 || state.editObj.couponType==4 || state.editObj.couponType==5 || state.editObj.couponType==6))")
                    el-option(v-for="(item, index) in state.sendConditionOptions" :label="item.label" :value="item.value" :key="`sendCondition-${index}`") 
            </el-col>
        </el-row>
    </el-form-item>
    <el-form-item label="">
        <el-row>
            <el-col :span="8"> 
                span.coupon-edit__span_bold 發送限制
                span &emsp;
                el-select.coupon-edit__select.ob-ml-1(v-model="state.editObj.sendLimitType" )
                    el-option(v-for="(item, index) in state.sendLimitTypeOptions" :label="item.label" :value="item.value" :key="`sendLimitType-${index}`") 
            </el-col>
            <el-col :span="16"></el-col>
        </el-row>
    </el-form-item>
    <el-form-item label="">
        <el-row>
            <el-col :span="2"> 
                span.coupon-edit__span_bold 可以使用的時間
            </el-col>
            <el-col :span="12"> 
                el-radio-group(v-model="state.editObj.canUseType" style="margin-top: -1%")
                    el-radio(:label="0" style="margin-top: 3%" v-model="state.editObj.canUseType" @change="canUseTypeOnChange($event)" :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==2 || state.editObj.couponType==3 || state.editObj.couponType==4))")
                        span 系統自動取用
                    el-radio(:label="1" style="margin-top: 3%" v-model="state.editObj.canUseType" @change="canUseTypeOnChange($event)" :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==2 || state.editObj.couponType==3 || state.editObj.couponType==4 || state.editObj.couponType==5 || state.editObj.couponType==6))")
                        span 時間區間
                        el-date-picker(:disabled="state.editObj.canUseType!=1 || (/*state.action=='add' &&*/ (state.editObj.couponType==2 || state.editObj.couponType==3 || state.editObj.couponType==4 || state.editObj.couponType==5 || state.editObj.couponType==6))" 
                                        v-model="state.editObj.canUseStartDate" type="date" value-format="yyyy-MM-dd" style="width:40%;")
                        span &nbsp;～&nbsp;
                        el-date-picker(:disabled="state.editObj.canUseType!=1 || (/*state.action=='add' &&*/ (state.editObj.couponType==2 || state.editObj.couponType==3 || state.editObj.couponType==4 || state.editObj.couponType==5 || state.editObj.couponType==6))" 
                                        v-model="state.editObj.canUseEndDate" type="date" value-format="yyyy-MM-dd" style="width:40%;")
                    el-radio(:label="2" style="margin-top: 3%" v-model="state.editObj.canUseType" @change="canUseTypeOnChange($event)" :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==5 || state.editObj.couponType==6))")
                        span 歸戶後&emsp;
                        el-input(maxlength="3" @keypress="isNumber($event)" :disabled="state.editObj.canUseType!=2 || (/*state.action=='add' &&*/ (state.editObj.couponType==5 || state.editObj.couponType==6))" v-model="state.strCanUseByReceiveDay" style="width:20%;")
                        span &emsp;天內可使用
            </el-col>
            <el-col :span="2"></el-col>
            <el-col :span="8">
                span.coupon-edit__span_bold 使用限制
                span &emsp;
                el-select.coupon-edit__select.ob-ml-1(v-model="state.editObj.useLimitType" :disabled="(/*state.action=='add' &&*/ state.editObj.couponType==6)")
                    el-option(v-for="(item, index) in state.useLimitTypeOptions" :label="item.label" :value="item.value" :key="`useLimitType-${index}`") 
            </el-col>
        </el-row>
    </el-form-item>
    <el-form-item label="">
        <el-row>
            <el-col :span="8"> 
                span.coupon-edit__span_bold 產出類型
                span &emsp;
                el-radio-group(v-model="state.editObj.outputType")
                    el-radio(:label="1" v-model="state.editObj.outputType" :disabled="state.action=='update'")
                        span 即時產出
                    el-radio(:label="2" v-model="state.editObj.outputType" :disabled="state.action=='update'")
                        span 預先產出
            </el-col>
            <el-col :span="8"></el-col>
            <el-col :span="1">
                span.coupon-edit__span_bold 對象
            </el-col>
            <el-col :span="3">
                el-radio-group(v-model="state.editObj.sendTarget" style="margin-top: 1%")
                    el-radio(:label="1" style="margin-top: 5%" v-model="state.editObj.sendTarget" :disabled="(/*state.action=='add' &&*/ state.editObj.couponType==5)")
                        span 全部會員
                    el-radio(:label="2" style="margin-top: 5%" v-model="state.editObj.sendTarget" :disabled="(/*state.action=='add' &&*/ state.editObj.couponType==5)")
                        span 一般會員
                    el-radio(:label="3" style="margin-top: 5%" v-model="state.editObj.sendTarget")
                        span 訂閱會員(季)
                    el-radio(:label="4" style="margin-top: 5%" v-model="state.editObj.sendTarget" :disabled="(/*state.action=='add' &&*/ state.editObj.couponType==5)")
                        span 指定會員
                        span &emsp;
                        <input type="file" id="uploads" style="position:absolute; clip:rect(0 0 0 0);" @change="uploadMembersList($event.target.files[0])" />
                        el-button(size="small" type="primary" onclick="document.formEdit.uploads.value = '';document.formEdit.uploads.click()" :disabled="state.editObj.sendTarget!=4 || (/*state.action=='add' &&*/ state.editObj.couponType==5)") 上傳名單
                        span &emsp;{{ `${state.uploadMsg}` }} 
            </el-col>
            <el-col :span="4"></el-col>
        </el-row>
    </el-form-item>
    <el-form-item label="">
        <el-row>
            <el-col :span="8"> 
                span.coupon-edit__span_bold 總數限量
                span &emsp;
                el-input.coupon-edit__input_1(v-model="state.strLimitQuantity" maxlength="6" :disabled="state.action=='update'" @keypress="isNumber($event)" style="width:25%;") 
                span &nbsp;張
            </el-col>
            <el-col :span="16"></el-col>
        </el-row>
    </el-form-item>
    <el-form-item label="">
        <el-row>
            <el-col :span="2"> 
                span.coupon-edit__span_bold 優惠項目
            </el-col>
            //-<el-col :span="1"> 
            //-</el-col>
            <el-col :span="4"> 
                el-checkbox(:label="1" @change="cartTypeOnChange($event)" v-model="state.cartType1" :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==5 || state.editObj.couponType==6))")
                    span 服務訂單(服務方案)
                el-checkbox(:label="2" @change="cartTypeOnChange($event)" v-model="state.cartType2")
                    span 商品訂單(盒內商品)
                el-checkbox(:label="3" @change="cartTypeOnChange($event)" v-model="state.cartType3" :disabled="(/*state.action=='add' &&*/ (state.editObj.couponType==5 || state.editObj.couponType==6))")
                    span 商品訂單(直購)
            </el-col>
            <el-col :span="10"></el-col>
            <el-col :span="2">
                span.coupon-edit__span_bold 優惠門檻
            </el-col>
            <el-col :span="6">
                el-radio-group(v-model="state.editObj.discountThresholdType"  style="margin-top: -1%")
                    el-radio(:label="0" style="margin-top: 5%" v-model="state.editObj.discountThresholdType" @change="discountThresholdOnChange($event)")
                        span 無
                    el-radio(:label="1" style="margin-top: 5%" v-model="state.editObj.discountThresholdType" @change="discountThresholdOnChange($event)" :disabled="state.cartType1")
                        span 滿&emsp;
                        el-input(v-model="state.discountThresholdValue1" maxlength="3" @keypress="isNumber($event)" :disabled="state.editObj.discountThresholdType!=1 || state.cartType1" class="coupon-edit__input_2")
                        span &emsp;件
                    el-radio(:label="2" style="margin-top: 5%" v-model="state.editObj.discountThresholdType" @change="discountThresholdOnChange($event)" :disabled="state.cartType1")
                        span 滿&emsp;
                        el-input(v-model="state.discountThresholdValue2" maxlength="5" @keypress="isNumber($event)" :disabled="state.editObj.discountThresholdType!=2 || state.cartType1" class="coupon-edit__input_2")
                        span &emsp;元
            </el-col>
        </el-row>
    </el-form-item>
    <el-form-item label="">
        <el-row>
            <el-col :span="8"> 
                span.coupon-edit__span_bold 優惠目標
                span &emsp;
                el-select.coupon-edit__select.ob-ml-1(v-model="state.editObj.discountTarget" )
                    el-option(v-for="(item, index) in state.discountTargetOptions" :label="item.label" :value="item.value" :key="`discountTarget-${index}`") 
            </el-col>
            <el-col :span="8"></el-col>
            <el-col :span="2">
                span.coupon-edit__span_bold 優惠內容
            </el-col>     
            <el-col :span="6">
                el-radio-group(v-model="state.editObj.discountContentType" style="margin-top: -5%")
                    el-radio(:label="1" style="margin-top: 5%" v-model="state.editObj.discountContentType" @change="discountContentOnChange($event)")
                        span 折&emsp;
                        el-input(v-model="state.discountContentValue1" maxlength="5" @keypress="isNumber($event)" :disabled="state.editObj.discountContentType!=1" class="coupon-edit__input_2")
                        span &emsp;元
                    el-radio(:label="2" style="margin-top: 5%" v-model="state.editObj.discountContentType" @change="discountContentOnChange($event)")
                        span 打&emsp;
                        el-input(v-model="state.discountContentValue2" maxlength="2" @keypress="isNumber($event)" :disabled="state.editObj.discountContentType!=2" class="coupon-edit__input_2")
                        span &emsp;折
            </el-col>         
        </el-row>
    </el-form-item>

    <el-form-item label="">
        <el-row>
            <el-col :span="8"> 
                <el-button size="medium" type="primary" @click="remove" v-if="state.action=='update' && state.editObj.status!='進行中' && state.editObj.status!='已結束'">刪除</el-button>
            </el-col>
            <el-col :span="8"></el-col>
            <el-col :span="8">
                <el-button size="medium" type="primary" @click="cancel">取消</el-button>
                <el-button size="medium" type="primary" @click="save">儲存</el-button>
            </el-col>
        </el-row>
    </el-form-item> 

</el-form>
</div>
</template>

<script lang="ts">
import { defineComponent, onMounted, reactive } from 'vue';

import {
    GetCouponById,
    GetCouponByType,
    CouponSubmit,
    CouponRemove,
    UploadMembersList
} from '@/_api/coupon.api';
import CouponEditResultModel from '@/models/coupon/CouponEditResultModel';
import CouponSubmitParamsModel from '@/models/coupon/CouponSubmitParamsModel';
import CouponRemoveParamsModel from '@/models/coupon/CouponRemoveParamsModel';

import { ElMessageBox } from 'element-plus';
import { useRoute, useRouter } from 'vue-router';
import { SetLoading } from '@/_utils/common';

export default defineComponent({
    name: 'CouponEdit',
    components: {},
    setup() {
        const route = useRoute();
        const router = useRouter();

        const state = reactive({
            action: '',

            editObj: new CouponEditResultModel(),
            submitObj: new CouponSubmitParamsModel(),
            removeObj: new CouponRemoveParamsModel(),

            discountThresholdValue1: '',
            discountThresholdValue2: '',
            discountContentValue1: '',
            discountContentValue2: '',

            //checkbox值綁定用
            cartType1: false,
            cartType2: false,
            cartType3: false,

            //歸戶天數
            strCanUseByReceiveDay: '',

            //限量張數
            strLimitQuantity: '',

            //上傳後訊息
            uploadMsg: '',

            receiveTypeOptions: [
                {
                    value: 0,
                    label: '請選擇'
                },
                {
                    value: 1,
                    label: '使用者手動領取/歸戶'
                },
                {
                    value: 2,
                    label: '使用者結帳後歸戶'
                },
                {
                    value: 3,
                    label: '系統自動歸戶'
                }
            ],

            sendConditionOptions: [
                {
                    value: 0,
                    label: '請選擇'
                },
                {
                    value: 1,
                    label: '服務方案續訂訂單成立'
                },
                {
                    value: 2,
                    label: '商品訂單(盒內商品)結帳時'
                },
                {
                    value: 3,
                    label: '生日月為發送日當月'
                }
            ],

            sendLimitTypeOptions: [
                {
                    value: 0,
                    label: '請選擇'
                },
                {
                    value: 1,
                    label: '活動區間內限領用１張'
                },
                {
                    value: 2,
                    label: '活動區間內每天限領用１張'
                }
            ],

            useLimitTypeOptions: [
                {
                    value: 0,
                    label: '請選擇'
                },
                {
                    value: 1,
                    label: '第一張服務訂單成立'
                },
                {
                    value: 2,
                    label: '盒內商品數全滿(含加衣券)'
                }
            ],

            cartTypeOptions: [
                {
                    value: 1,
                    label: '服務訂單(服務方案)'
                },
                {
                    value: 2,
                    label: '商品訂單(盒內商品)'
                },
                {
                    value: 3,
                    label: '商品訂單(直購)'
                }
            ],

            discountTargetOptions: [
                {
                    value: 0,
                    label: '請選擇'
                },
                {
                    value: 1,
                    label: '商品總金額'
                }
            ]
        });

        const stateVariableConvert = () => {
            if (
                state.editObj.discountThresholdType == 1 &&
                state.editObj.discountThresholdValue > 0
            ) {
                state.discountThresholdValue1 = state.editObj.discountThresholdValue.toString();
            }

            if (
                state.editObj.discountThresholdType == 2 &&
                state.editObj.discountThresholdValue > 0
            ) {
                state.discountThresholdValue2 = state.editObj.discountThresholdValue.toString();
            }

            if (
                state.editObj.discountContentType == 1 &&
                state.editObj.discountContentValue > 0
            ) {
                state.discountContentValue1 = state.editObj.discountContentValue.toString();
            }

            if (
                state.editObj.discountContentType == 2 &&
                state.editObj.discountContentValue > 0
            ) {
                state.discountContentValue2 = state.editObj.discountContentValue.toString();
            }

            //優惠項目 checkbox設定值
            if (state.editObj.cartType.trim() != '') {
                const cartTypeArr = state.editObj.cartType.trim().split(',');
                for (const key in cartTypeArr) {
                    if (cartTypeArr[key] == '1') {
                        state.cartType1 = true;
                    }
                    if (cartTypeArr[key] == '2') {
                        state.cartType2 = true;
                    }
                    if (cartTypeArr[key] == '3') {
                        state.cartType3 = true;
                    }
                }
            }

            //歸戶天數
            if (state.editObj.canUseByReceiveDay > 0)
                state.strCanUseByReceiveDay = state.editObj.canUseByReceiveDay.toString();

            //限量張數
            if (state.editObj.limitQuantity > 0)
                state.strLimitQuantity = state.editObj.limitQuantity.toString();
        };

        onMounted(async () => {
            try {
                SetLoading(true);

                //新增
                const CouponType = route.query.type?.toString();
                if (CouponType) {
                    state.action = 'add';

                    const { data } = await GetCouponByType(
                        parseInt(CouponType)
                    );
                    state.editObj = data.data as CouponEditResultModel;

                    stateVariableConvert();
                }

                //編輯
                const id = route.query.id?.toString();
                if (id) {
                    state.action = 'update';

                    const { data } = await GetCouponById(id);
                    state.editObj = data.data as CouponEditResultModel;

                    stateVariableConvert();
                }
            } catch (error) {
                console.log(error);
            }
            SetLoading();
        });

        const formatDate = (marketingActivityDate: string) => {
            const date = new Date(marketingActivityDate);

            return (
                date.getFullYear() +
                '-' +
                (date.getMonth() + 1 >= 10
                    ? date.getMonth() + 1
                    : '0' + (date.getMonth() + 1)) +
                '-' +
                (date.getDate() >= 10 ? date.getDate() : '0' + date.getDate())
            );
        };

        const backToHome = () => {
            router.push({
                path: '/coupon-management/query'
            });
        };

        const goToDetail = () => {
            const params = {
                Id: state.editObj.id
            };

            router.push({
                path: '/coupon-management/detail',
                query: params
            });
        };

        const cancel = () => {
            router.push({
                path: '/coupon-management/query'
            });
        };

        const isValid = () => {
            if (state.editObj.receiveType == 0) {
                ElMessageBox.alert('請選擇領取/歸戶方式');
                return false;
            }

            if (state.editObj.outputType == 1) {
                //即時產出

                if (
                    state.editObj.specialCode == undefined ||
                    state.editObj.specialCode == ''
                ) {
                    ElMessageBox.alert('請輸入指定碼');
                    return false;
                }
            }

            if (
                state.editObj.marketingActivityStartDate == null ||
                state.editObj.marketingActivityEndDate == null ||
                state.editObj.marketingActivityStartDate == '' ||
                state.editObj.marketingActivityEndDate == ''
            ) {
                ElMessageBox.alert('請輸入活動時間');
                return false;
            }

            const nowDate = new Date();
            const marketingActivityStartDate = new Date(
                state.editObj.marketingActivityStartDate
            );
            const marketingActivityEndDate = new Date(
                state.editObj.marketingActivityEndDate
            );
            if (marketingActivityStartDate <= nowDate) {
                ElMessageBox.alert(
                    '活動開始日，不允許輸入當天日期或早於當天日期'
                );
                return false;
            }

            if (marketingActivityEndDate < marketingActivityStartDate) {
                ElMessageBox.alert('活動結束日不可早於活動開始日');
                return false;
            }

            if (state.editObj.couponType == 2) {
                //專屬生日禮

                const differenceInTime =
                    marketingActivityEndDate.getTime() -
                    marketingActivityStartDate.getTime();

                const differenceInDays = differenceInTime / (1000 * 3600 * 24);

                if (differenceInDays > 365) {
                    ElMessageBox.alert('專屬生日禮-活動區間不可超過一年');
                    return false;
                }
            }

            if (state.editObj.sendCondition == 0) {
                ElMessageBox.alert('請選擇發送條件');
                return false;
            }

            // if (state.editObj.sendLimitType == 0){
            //     ElMessageBox.alert("請選擇發送限制");
            //     return false;
            // }

            if (state.editObj.canUseType == 1) {
                //時間區間

                if (
                    state.editObj.canUseStartDate != null &&
                    state.editObj.canUseEndDate != null
                ) {
                    const canUseStartDate = new Date(
                        state.editObj.canUseStartDate
                    );
                    const canUseEndDate = new Date(state.editObj.canUseEndDate);
                    if (canUseEndDate < canUseStartDate) {
                        ElMessageBox.alert(
                            '可以使用結束日不可早於可以使用開始日'
                        );
                        return false;
                    }
                }
            }

            if (state.editObj.canUseType == 2) {
                //歸戶後n天可使用
                if (state.strCanUseByReceiveDay == '') {
                    ElMessageBox.alert('請輸入歸戶後可使用天數');
                    return false;
                }
            }

            if (state.editObj.useLimitType == 0) {
                ElMessageBox.alert('請選擇使用限制');
                return false;
            }

            if (state.strLimitQuantity == '') {
                ElMessageBox.alert('請輸入限量張數');
                return false;
            }

            if (
                state.cartType1 == false &&
                state.cartType2 == false &&
                state.cartType3 == false
            ) {
                ElMessageBox.alert('請勾選優惠項目');
                return false;
            }

            if (
                state.editObj.discountThresholdType == 1 &&
                state.discountThresholdValue1 == ''
            ) {
                ElMessageBox.alert('請輸入優惠門檻-滿幾元');
                return false;
            }

            if (
                state.editObj.discountThresholdType == 2 &&
                state.discountThresholdValue2 == ''
            ) {
                ElMessageBox.alert('請輸入優惠門檻-滿幾件');
                return false;
            }

            if (state.editObj.discountTarget == 0) {
                ElMessageBox.alert('請選擇優惠目標');
                return false;
            }

            if (
                state.editObj.discountContentType == 1 &&
                state.discountContentValue1 == ''
            ) {
                ElMessageBox.alert('請輸入優惠內容-折幾元');
                return false;
            }

            if (
                state.editObj.discountContentType == 2 &&
                state.discountContentValue2 == ''
            ) {
                ElMessageBox.alert('請輸入優惠內容-打幾折');
                return false;
            }

            return true;
        };

        const save = async () => {
            if (!isValid()) return;

            state.submitObj.Id = state.editObj.id;
            state.submitObj.CouponRuleId = state.editObj.couponRuleId;
            state.submitObj.MarketingActivitiesId =
                state.editObj.marketingActivitiesId;
            state.submitObj.CouponName = state.editObj.couponName;
            state.submitObj.SpecialCode = state.editObj.specialCode;

            let saveCartType = '';
            if (state.cartType1 == true) saveCartType += '1,';
            if (state.cartType2 == true) saveCartType += '2,';
            if (state.cartType3 == true) saveCartType += '3,';
            if (saveCartType != '')
                saveCartType = saveCartType.substr(0, saveCartType.length - 1);
            state.submitObj.CartType = saveCartType;

            state.submitObj.DiscountThresholdType =
                state.editObj.discountThresholdType;
            if (
                state.editObj.discountThresholdType == 1 &&
                state.discountThresholdValue1 != ''
            ) {
                state.submitObj.DiscountThresholdValue = parseInt(
                    state.discountThresholdValue1
                );
            }
            if (
                state.editObj.discountThresholdType == 2 &&
                state.discountThresholdValue2 != ''
            ) {
                state.submitObj.DiscountThresholdValue = parseInt(
                    state.discountThresholdValue2
                );
            }

            state.submitObj.DiscountTarget = state.editObj.discountTarget;

            state.submitObj.DiscountContentType =
                state.editObj.discountContentType;
            if (
                state.editObj.discountContentType == 1 &&
                state.discountContentValue1 != ''
            ) {
                state.submitObj.DiscountContentValue = parseInt(
                    state.discountContentValue1
                );
            }
            if (
                state.editObj.discountContentType == 2 &&
                state.discountContentValue2 != ''
            ) {
                state.submitObj.DiscountContentValue = parseInt(
                    state.discountContentValue2
                );
            }

            state.submitObj.CouponTypeName = state.editObj.couponTypeName;
            state.submitObj.CouponType = state.editObj.couponType;
            state.submitObj.ReceiveType = state.editObj.receiveType;

            if (
                state.editObj.marketingActivityStartDate != null &&
                state.editObj.marketingActivityStartDate != ''
            ) {
                state.submitObj.MarketingActivityStartDate =
                    formatDate(state.editObj.marketingActivityStartDate) +
                    ' 00:00:00';
            }

            if (
                state.editObj.marketingActivityEndDate != null &&
                state.editObj.marketingActivityEndDate != ''
            ) {
                state.submitObj.MarketingActivityEndDate =
                    formatDate(state.editObj.marketingActivityEndDate) +
                    ' 23:59:59';
            }

            state.submitObj.CanUseType = state.editObj.canUseType;

            if (
                state.editObj.canUseStartDate != null &&
                state.editObj.canUseStartDate != ''
            ) {
                state.submitObj.CanUseStartDate =
                    formatDate(state.editObj.canUseStartDate) + ' 00:00:00';
            }

            if (
                state.editObj.canUseEndDate != null &&
                state.editObj.canUseEndDate != ''
            ) {
                state.submitObj.CanUseEndDate =
                    formatDate(state.editObj.canUseEndDate) + ' 23:59:59';
            }

            if (state.strCanUseByReceiveDay != '')
                state.submitObj.CanUseByReceiveDay = parseInt(
                    state.strCanUseByReceiveDay
                );

            if (state.strLimitQuantity != '')
                state.submitObj.LimitQuantity = parseInt(
                    state.strLimitQuantity
                );

            state.submitObj.SendCondition = state.editObj.sendCondition;
            state.submitObj.SendLimitType = state.editObj.sendLimitType;
            state.submitObj.SendTarget = state.editObj.sendTarget;
            state.submitObj.OutputType = state.editObj.outputType;
            state.submitObj.UseLimitType = state.editObj.useLimitType;

            try {
                SetLoading(true);
                const response = await CouponSubmit(state.submitObj);
                SetLoading();

                ElMessageBox.alert(response.data.data.message);

                if (response.data.data.message == '儲存成功') {
                    router.push({
                        path: '/coupon-management/query'
                    });
                }
            } catch (error) {
                console.log(error);
            }

            // const response = await CouponSubmit(state.submitObj);
            // ElMessageBox.alert(response.data.data.message);

            // if (response.data.data.message == "儲存成功"){

            //     router.push({
            //         path: '/coupon-management/query',
            //     });
            // }
        };

        const remove = () => {
            ElMessageBox.confirm('確定要刪除Coupon？', '').then(async () => {
                state.removeObj.Id = state.editObj.id;
                const response = await CouponRemove(state.removeObj);

                //ElMessageBox.alert(response.data.data.message);

                if (response.data.data.message == '刪除成功') {
                    router.push({
                        path: '/coupon-management/query'
                    });
                }
            });
        };

        const canUseTypeOnChange = (value: string) => {
            if (value != '1') {
                state.editObj.canUseStartDate = '';
                state.editObj.canUseEndDate = '';
            }

            if (value != '2') {
                state.strCanUseByReceiveDay = '';
            }
        };

        const discountThresholdOnChange = (value: string) => {
            if (value != '1') state.discountThresholdValue1 = '';
            if (value != '2') state.discountThresholdValue2 = '';
        };

        const discountContentOnChange = (value: string) => {
            if (value != '1') state.discountContentValue1 = '';
            if (value != '2') state.discountContentValue2 = '';
        };

        const cartTypeOnChange = (value: string) => {
            console.log(value);
            if (state.cartType1 == true) {
                state.editObj.discountThresholdType = 0;
                state.discountThresholdValue1 = '';
                state.discountThresholdValue2 = '';
            }
        };

        const isNumber = (e: KeyboardEvent) => {
            const charCode = e.charCode;

            if (
                charCode > 31 &&
                (charCode < 48 || charCode > 57) /*&& charCode !== 46*/
            ) {
                e.preventDefault();
            }

            return true;
        };

        const uploadMembersList = async (file: {}) => {
            const formData = new FormData();
            formData.append('file', file as Blob);

            const response = await UploadMembersList(formData);

            state.uploadMsg =
                '本次共匯入' +
                response.data.data.uploadedCount.toString() +
                '筆';
        };

        return {
            state,
            backToHome,
            goToDetail,
            cancel,
            save,
            remove,
            canUseTypeOnChange,
            discountThresholdOnChange,
            discountContentOnChange,
            cartTypeOnChange,
            isNumber,
            uploadMembersList
        };
    }
});
</script>

<style lang="scss">
@import '@/styles/element-variables.scss';
.coupon-edit {
    &__search-bar {
        width: 100%;
        border: $--table-border;
        padding: 10px 5px;
    }
    &__search-item {
        float: right;
        margin-bottom: 0;
    }
    &__table {
        margin-top: 30px;
    }

    &__select {
        width: 60%;
    }

    &__span_bold {
        font-weight: bold;
    }
    &__input_1 {
        width: 60%;
    }
    &__input_2 {
        width: 30%;
    }
}
</style>
